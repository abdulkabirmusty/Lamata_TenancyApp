using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System.Threading.Tasks;
using System;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.PropertyDtos;
using Tenant_App.Services.Contract.DamagesContract;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Utilities.ExceptionUtility;
using Tenant_App.Models.DataObjects.DamageDtos;
//using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Linq;
using Tenant_App.Utilities.Enums;
using System.Collections.Generic;

namespace Tenant_App.Web.Controllers
{
    public class DamageController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IDamage _damage;
        private readonly log4net.Core.ILogger _logger;
        private readonly IErrorLogger _errorLogger;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public DamageController(AppDbContext appDbContext, IDamage damage, ILogger<DamageController> logger, IErrorLogger errorLogger,
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
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = _context.Roles.FirstOrDefault(x => x.Name == "Admin");
            var userRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == role.Id);
            
            List<FetchDamageDto> damages;

            if (userRole != null)
            {
                damages = _damage.GetAllDamages();
            }
            else
            {
                damages = _damage.GetAllDamages(userId);
            }
            
            return View(damages);
        }

        [HttpGet("Damage/Create")]
        public IActionResult Create()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _context.Users
                .Where(x => x.Id == userId)
                .FirstOrDefault();
            DateTime today = DateTime.UtcNow;
            var userProperty = _context.PropertyTenants
                .Where(t => t.UserID == userId && t.expiryDate > today && t.ApprovalStatus == 1).FirstOrDefault();

            if(userProperty == null)
            {
                _toastNotification.AddWarningToastMessage("Logged in user is not a tenant", null);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.FullName = user.FirstName + " " + user.LastName;
            ViewBag.PropertyName = userProperty.PropertiesName;
            ViewBag.PropertyId = userProperty.PropertiesId;

            return PartialView("_AddDamage");
        }

        [HttpPost("Damage/Create")]
        public async Task<IActionResult> Create(DamageDto model)
        {
            try
            {
				var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                model.UserId = userId;
                model.status = nameof(DamageStatusEnum.Reported);

				var response = await _damage.CreateDamageReport(model);

                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.Succesful, null);

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return systemError(ex);
            }

        }

        [HttpGet("Damage/Edit")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var response = await _damage.GetDamagesById(Id);
            return PartialView("_EditDamage", response);
        }

        [HttpPost("Damage/Edit")]
        public async Task<IActionResult> Edit(DamageDto model, Guid id)
        {
            try
            {
                
                var response = await _damage.UpdateDamage(model, id);

                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.UpdateRecord, null);

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return systemError(ex);
            }

        }

        [HttpGet("Damage/Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var response = await _damage.GetDamagesById(Id);
            return PartialView("_DeleteDamage", response);
        }

        [HttpPost("Damage/Delete")]
        public async Task<IActionResult> Delete(DamageDto model, Guid id)
        {
            try
            {
                
                var response = await _damage.DeleteDamage(id);

                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.DeleteOperation, null);

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return systemError(ex);
            }

        }

        [HttpGet("Damage/Preview")]
        public async Task<IActionResult> Preview(Guid Id)
        {
            var response = await _damage.GetDamagesById(Id);
            return PartialView("_PreviewDamage", response);
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
