using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.DamageDtos;
using Tenant_App.Services.Contract.DamagesContract;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Utilities.Enums;
using Tenant_App.Utilities.ExceptionUtility;

namespace Tenant_App.Web.Controllers
{
    public class MaintenanceController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IDamage _damage;
        private readonly log4net.Core.ILogger _logger;
        private readonly IErrorLogger _errorLogger;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public MaintenanceController(AppDbContext appDbContext, IDamage damage, ILogger<MaintenanceController> logger, IErrorLogger errorLogger,
            IToastNotification toastNotification, IWebHostEnvironment hostingEnvironment)
        {
            _context = appDbContext;
            _damage = damage;
            _errorLogger = errorLogger;
            _toastNotification = toastNotification;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var damages = _damage.GetAllDamages();
            return View(damages);
        }

        [HttpGet("Maintenance/Preview")]
        public async Task<IActionResult> Preview(Guid Id)
        {
            var response = await _damage.GetDamagesById(Id);
            return PartialView("_PreviewDamage", response);
        }

        [HttpPost("Maintenance/Edit")]
        public async Task<IActionResult> Edit(DamageDto model, Guid id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                model.UserId = userId;
                model.status = nameof(DamageStatusEnum.Resolved);

                var response = await _damage.UpdateAdminComment(model, id);

                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.UpdateRecord, null);

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return systemError(ex);
            }

        }

        public RedirectToActionResult systemError(Exception ex)
        {
            _errorLogger.LogError(ex, GetControllerAndActionName(this));
            _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.OperationFailed_Ex, null);

            ModelState.Clear();

            return RedirectToAction(nameof(Index));
        }
    }
}
