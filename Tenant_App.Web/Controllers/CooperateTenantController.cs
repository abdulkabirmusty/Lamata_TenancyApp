using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Threading.Tasks;
using Tenant_App.Models.Constants;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.CooperateTenantDtos;
using Tenant_App.Services.Contract.CooperateTenantContract;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Utilities.ExceptionUtility;

namespace Tenant_App.Web.Controllers
{
    public class CooperateTenantController : BaseController
	{
        private readonly AppDbContext _context;
        private readonly ICooperateTenant _tenant;
		private readonly IErrorLogger _errorLogger;
		private readonly IToastNotification _toastNotification;

		public CooperateTenantController(AppDbContext context, ICooperateTenant tenant, IErrorLogger errorLogger, IToastNotification toastNotification)
		{
            _context = context;
            _tenant = tenant;
			_errorLogger = errorLogger;
			_toastNotification = toastNotification;
		}

		public IActionResult Index()
		{
			List<CooperateTenantDto> individualTenantDTO = _tenant.GetAllCooperateTenant();
			return View(individualTenantDTO);
		}

        [HttpPost]
        [Route("CooperateTenant/AcceptTenant")]
        [Authorize]
        public async Task<IActionResult> AcceptTenant(Guid id)
        {
            try
            {
                await _tenant.AcceptCooperateTenants(new List<Guid> { id }, CurrentUser.UserId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                SystemError(ex);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Route("CooperateTenant/RejectTenant")]
        [Authorize]
        public async Task<IActionResult> RejectTenant(Guid id)
        {
            try
            {
                await _tenant.RejectCooperateTenants(new List<Guid> { id }, CurrentUser.UserId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                SystemError(ex);
                return RedirectToAction("Index");
            }
        }

        [Route("CooperateTenant/ViewCooperateTenant/{id}")]
        [Authorize]
        public IActionResult ViewCooperateTenant(Guid id)
        {
            try
            {
                var cooperateTenant = _context.CooperateTenants.Where(c => c.Id  == id).FirstOrDefault();

                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userStatus = _context.Users.Where(u => u.Email == cooperateTenant.CooperateEmail).Select(u => u.Status).FirstOrDefault();

                var adminRole = _context.Roles.FirstOrDefault(x => x.Name == Roles.ADMIN);
                var deskOfficerRole = _context.Roles.FirstOrDefault(x => x.Name == Roles.DESKOFFICER);
                var deskUserRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == deskOfficerRole.Id);
                var adminUserRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == adminRole.Id);

                CooperateTenantDto tenantDTO = _tenant.ViewCoperateTenant(id);

                if (userStatus == 0 && deskOfficerRole != null)
                {
                    ViewBag.IsDeskOfficer = true;
                }
                else if (userStatus == 1 && adminUserRole != null)
                {
                    ViewBag.IsAdmin = true;
                }

                ViewBag.Status = userStatus;

                return View(tenantDTO);
            }
            catch (Exception ex)
            {
                SystemError(ex);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult ApprovedTenant()
        {
            List<CooperateTenantDto> tenantList = _tenant.GetAcceptedCooperateTenant();
            return View(tenantList);
        }

        public void SystemError(Exception ex)
        {
            _errorLogger.LogError(ex, GetControllerAndActionName(this));
            _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.OperationFailed_Ex, null);

            ModelState.Clear();
        }

        [Route("CooperateTenant/DownloadFile/{filePath}")]
        [Authorize]
        public IActionResult DownloadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return BadRequest("File path is not provided.");
            }

            filePath = Uri.UnescapeDataString(filePath);

            var fileFullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

            if (!System.IO.File.Exists(fileFullPath))
            {
                return NotFound("File not found.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(fileFullPath);
            var fileName = Path.GetFileName(fileFullPath);
            return File(fileBytes, "application/octet-stream", fileName);
        }

    }
}
