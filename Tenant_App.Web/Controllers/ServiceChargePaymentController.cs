using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DTOs;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Services.Contract.ServiceCharge;
using Tenant_App.Web.Filters;

namespace Tenant_App.Web.Controllers
{
	public class ServiceChargePaymentController : BaseController
	{
		private readonly AppDbContext _context;
		private readonly ILogger<ServiceChargePaymentController> _logger;
		private readonly IServiceChargeService _serviceChargeService;
		private readonly IErrorLogger _errorLogger;
		private readonly IToastNotification _toastNotification;

		public ServiceChargePaymentController(AppDbContext context, IServiceChargeService serviceChargeService,
											  ILogger<ServiceChargePaymentController> logger, IErrorLogger errorLogger,
											  IToastNotification toastNotification)
		{
			_context = context;
			_serviceChargeService = serviceChargeService;
			_logger = logger;
			_errorLogger = errorLogger;
			_toastNotification = toastNotification;
		}

		public async Task<IActionResult> Index()
		{
			var userId = CurrentUser.UserId;
			var userServiceCharges = await _serviceChargeService.GetServiceChargesForUserAsync(userId);
			return View(userServiceCharges);
		}

		[HttpGet("ServiceChargePayment/Pay/{serviceChargeId}")]
		public async Task<IActionResult> Pay(Guid serviceChargeId)
		{
			ServiceChargeDto serviceCharge = null;

			try
			{
				serviceCharge = await _serviceChargeService.GetServiceChargeByIdAsync(serviceChargeId);
				serviceCharge.UserId = CurrentUser.UserId;

				if (serviceCharge == null)
				{
					return NotFound("Service charge not found.");
				}
			}
			catch (Exception ex)
			{
				// Log.Error(ex, "Error while fetching service charge details.");
				return StatusCode(500, "Internal server error while processing the request.");
			}

			return PartialView("_PayServiceCharge", serviceCharge);
		}

		[HttpPost("ServiceChargePayment/Pay")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Pay(ServiceChargePaymentDto paymentDto)
		{
			try
			{
				_logger.LogInformation($"Received payment details for ServiceChargeId: {paymentDto.ServiceChargeId}");

				var payment = await _serviceChargeService.MakeServiceChargePaymentAsync(
					paymentDto.ServiceChargeId,
					paymentDto.UserId,
					paymentDto.FrequencyId
				);

				if (payment != null)
				{
					HttpContext.Session.SetObjectAsJson("ServiceChargePayment", payment);

					return Json(new
					{
						success = true,
						redirectUrl = Url.Action("InitiateAndConfirmPayment", "Payment", new
						{
							serviceChargeIdHash = paymentDto.ServiceChargeId,
							amountToPay = payment.AmountToPay
						})
					});
				}
				else
				{
					_logger.LogWarning("Payment object is null.");
					return Json(new { success = false, message = "Failed to initiate payment." });
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error processing payment: {ex.Message}");
				return Json(new { success = false, message = "An error occurred while processing your payment. Please try again." });
			}
		}




		//[HttpPost("ServiceChargePayment/Pay/{serviceChargeId}")]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Pay(Guid serviceChargeId, string customerName, Guid frequencyId)
		//{
		//    if (string.IsNullOrWhiteSpace(customerName) || frequencyId == Guid.Empty)
		//    {
		//        _toastNotification.AddErrorToastMessage("Please provide valid customer details.");
		//        return PartialView("_PayServiceCharge");
		//    }

		//    try
		//    {
		//        var payment = await _serviceChargeService.MakeServiceChargePaymentAsync(serviceChargeId, customerName, frequencyId);

		//        if (payment != null)
		//        {
		//            _toastNotification.AddSuccessToastMessage("Payment was successful.");
		//            return RedirectToAction("Index");
		//        }

		//        _toastNotification.AddErrorToastMessage("Payment could not be processed.");
		//        return PartialView("_PayServiceCharge");
		//    }
		//    catch (Exception ex)
		//    {
		//        _logger.LogError($"Error processing payment: {ex.Message}");
		//        _toastNotification.AddErrorToastMessage("An error occurred during the payment process.");
		//        return PartialView("_PayServiceCharge");
		//    }
		//}
	}
}
