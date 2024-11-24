using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.DamageDtos;
using Tenant_App.Models.DataObjects.PaymentDtos;
using Tenant_App.Services.Contract.ContractTypeContract;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Services.Contract.PaymentContract;

namespace Tenant_App.Web.Controllers
{
    public class PaymentsController : BaseController
    {

        private readonly AppDbContext _context;
        private readonly log4net.Core.ILogger _logger;
        private readonly IPaymentService _payment;
        private readonly IErrorLogger _errorLogger;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _hostingEnvironment;
		private readonly IConverter _converter;
		private readonly ICompositeViewEngine _viewEngine;

		public PaymentsController(AppDbContext appDbContext, IPaymentService payment, ILogger<ContractTypeController> logger, IErrorLogger errorLogger,
            IToastNotification toastNotification, IWebHostEnvironment hostingEnvironment, IConverter converter,
			ICompositeViewEngine viewEngine)
        {
            _context = appDbContext;
            _payment = payment;
            _errorLogger = errorLogger;
            _toastNotification = toastNotification;
            _hostingEnvironment = hostingEnvironment;
			_converter = converter;
			_viewEngine = viewEngine;
		}

        public IActionResult Index()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = _context.Roles.FirstOrDefault(x => x.Name == "Admin");
            var userRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == role.Id);

            List<PaymentDto> paymentList;

            if (userRole != null)
			{
                paymentList = _payment.GetAllPayment();
            }
			else
			{
                paymentList = _payment.GetAllPayment(userId);
            }
                 
            return View(paymentList);
        }

        public async Task<IActionResult> GetReceipt(Guid id) 
        {
            var response = await _payment.GetPaymentById(id);
            return View(response);
        }

		[HttpGet]
		public async Task<IActionResult> DownloadReceipt(Guid id)
		{
			// Fetch the model based on the provided ID
			var model = await _payment.GetPaymentById(id);

			// Create the PDF document
			// Create the PDF document
			var doc = new HtmlToPdfDocument()
			{
				GlobalSettings = {
					ColorMode = ColorMode.Color,
					Orientation = Orientation.Portrait,
					PaperSize = PaperKind.A4,
					Margins = new MarginSettings {
						Top = 10,
						Bottom = 10,
						Left = 10,
						Right = 10
					}
				},
						Objects = {
					new ObjectSettings() {
						HtmlContent = await RenderViewToString("ReceiptView", model),
						WebSettings = { DefaultEncoding = "utf-8" }
					}
				}
			};

			// Convert the document to PDF
			var pdf = _converter.Convert(doc);

			// Return the PDF as a file download
			return File(pdf, "application/pdf", "Receipt.pdf");
		}

		private async Task<string> RenderViewToString(string viewName, object model)
		{
			ViewData.Model = model;
			using (var sw = new StringWriter())
			{
				var viewResult = _viewEngine.FindView(ControllerContext, viewName, false);
				var viewContext = new ViewContext(
					ControllerContext,
					viewResult.View,
					ViewData,
					TempData,
					sw,
					new HtmlHelperOptions()
				);
				await viewResult.View.RenderAsync(viewContext);
				return sw.ToString();
			}
		}
	}
}
