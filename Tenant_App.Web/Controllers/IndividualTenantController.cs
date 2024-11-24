using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Utilities.ExceptionUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Threading.Tasks;
using Tenant_App.Services.Contract.IndividualTenantContract;
using Tenant_App.Models.DataObjects.IndividualTenantDtos;
using Tenant_App.Models.Data;
using System.Linq;
using Tenant_App.Models.Domains.IndividualTenantDomain;
using System.Data.Entity;
using Tenant_App.Models.DTOs;
using System.Security.Claims;
using Tenant_App.Models.Constants;

namespace Tenant_App.Web.Controllers
{
    public class IndividualTenantController : BaseController
    {
        
        private readonly IIndividualTenant _tenant;
        private readonly IErrorLogger _errorLogger;
		private readonly IToastNotification _toastNotification;
        private readonly AppDbContext _context;
		public IndividualTenantController(AppDbContext context,IIndividualTenant tenant, IErrorLogger errorLogger, IToastNotification toastNotification)
        {
           
            _tenant = tenant;
            _errorLogger = errorLogger;
            _toastNotification = toastNotification;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
			var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userStatus = _context.Users.Where(u => u.Id == userId).Select(u => u.Status).FirstOrDefault();
            //to remove after clarity
			var adminRole = _context.Roles.FirstOrDefault(x => x.Name == Roles.ADMIN);
			var deskOfficerRole = _context.Roles.FirstOrDefault(x => x.Name == Roles.DESKOFFICER);
			var deskUserRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == deskOfficerRole.Id);
			var adminUserRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == adminRole.Id);

            List<IndividualTenantDto> individualTenantDTO;
            //needed to pass different records for each users, e.g desk officer wont see any other record that have been approved or reject.
            if(userStatus == 0 && deskOfficerRole != null)
            {
				individualTenantDTO = _tenant.GetAllIndividualTenant();
			}
            else if (userStatus == 1 && adminUserRole != null)
            {
				individualTenantDTO = _tenant.GetAllIndividualTenant();
			}
            else
            {
				individualTenantDTO = _tenant.GetAllIndividualTenant();
			}

            ViewBag.Status = userStatus;

			return View(individualTenantDTO);
        }

        [HttpPost]
        [Route("IndividualTenant/AcceptTenant")]
        [Authorize]
        public async Task<IActionResult> AcceptTenant(Guid id)
        {
            try
            {
                await _tenant.AcceptIndividual(new List<Guid> { id }, CurrentUser.UserId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                SystemError(ex);
                return RedirectToAction("Index");
            }
        }

		[HttpPost]
		[Route("IndividualTenant/RejectTenant")]
		[Authorize]
		public async Task<IActionResult> RejectTenant(Guid id)
		{
			try
			{
				await _tenant.RejectIndividual(new List<Guid> { id }, CurrentUser.UserId);

				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				SystemError(ex);
				return RedirectToAction("Index");
			}
		}

		[Route("IndividualTenant/ViewIndividualTenant/{id}")]
        [Authorize]
        public IActionResult ViewIndividualTenant(Guid id)
        {
            try
            {
                var getID = _context.IndividualTenants.Where(x => x.Id == id).FirstOrDefault();
                
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var userStatus = _context.Users.Where(u => u.Email == getID.Email).Select(u => u.Status).FirstOrDefault();

                var adminRole = _context.Roles.FirstOrDefault(x => x.Name == Roles.ADMIN);
                var deskOfficerRole = _context.Roles.FirstOrDefault(x => x.Name == Roles.DESKOFFICER);
                var deskUserRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == deskOfficerRole.Id);
                var adminUserRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == adminRole.Id);

                // Retrieve the individual tenant details including NextOfKin and Referees
                
                IndividualTenant individualTenant = _context.IndividualTenants
                    .Include(t => t.NextOfKin)
                    .Include(t => t.RentalHistory)
                    .Include(t => t.Referees)
                    .FirstOrDefault(t => t.Id == id);

                if (individualTenant == null)
                {
                    // Handle the case where the tenant is not found
                    return NotFound();
                }
                var getTenantId = _context.NextOfKin.Where(x => x.Id == getID.NextOfKinId).FirstOrDefault();
                var getrentalHistory = _context.RentalHistories.Where(x => x.Id == getID.RentalHistoryId).FirstOrDefault();
                // Map the IndividualTenant entity to IndividualTenantDto
                IndividualTenantDto tenantDTO = new IndividualTenantDto
                {
                    Id = individualTenant.Id,
                    FirstName = individualTenant.FirstName,
                    LastName = individualTenant.LastName,
                    CurrentAddress = individualTenant.CurrentAddress,
                    HomePhoneNo = individualTenant.HomePhoneNo,
                    WorkPhoneNo = individualTenant.WorkPhoneNo,
                    Status = individualTenant.Status,
                    Email = individualTenant.Email,
                    DOB = individualTenant.DOB,
                    Sex = individualTenant.Sex,
                    RentDuration = individualTenant.RentDuration,
                    Nationality = individualTenant.Nationality,
                    StateOfOrigin = individualTenant.StateOfOrigin,
                    IdentityType = individualTenant.IdentityType,
                    IdentityAttach = individualTenant.IdentityAttach,
                    SignaturePath = individualTenant.SignaturePath,
                    PassportPath = individualTenant.PassportPath,
                    nextOfKinFullName = getTenantId.FullName,
                    Relationship = getTenantId.Relationship,
                    NextOfKinAddress = getTenantId.Address,
                    NextOfKinEmail = getTenantId.Email,
                    NextOfKinMobilePhoneNo = getTenantId.MobilePhoneNo,
                    NextOfKinWorkPhoneNo = getTenantId.WorkPhoneNo,
                    PreviousAddress = getrentalHistory.PreviousAddress,
                    LengthOfTime = getrentalHistory.LengthOfTime,
                    Referees = _context.Referees.Where(r => r.IndividualTenantId==id).Select(r => new RefereeDto
                    {
                        FullName = r.FullName,
                        Relationship = r.Relationship,
                        MobileNo = r.MobileNo,
                        SignaturePath = r.SignaturePath
                    }).ToList()
                };

                if (userStatus == 0 && deskOfficerRole != null)
                {
                    ViewBag.IsDeskOfficer = true;
                }
                else if (userStatus == 1 && adminUserRole != null)
                {
                    ViewBag.IsAdmin = true;
                }

                ViewBag.Status = userStatus;

                // Pass the tenantDTO to the view
                return View(tenantDTO);
            }
            catch (Exception ex)
            {
                SystemError(ex);
                return RedirectToAction("Index");
            }
        }




        [Route("IndividualTenant/DownloadFile/{filePath}")]
        [Authorize]
        public IActionResult DownloadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return BadRequest("File path is not provided.");
            }

            // Ensure the file path is properly decoded
            filePath = Uri.UnescapeDataString(filePath);

            // Combine with the root path (adjust as necessary)
            var fileFullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

            if (!System.IO.File.Exists(fileFullPath))
            {
                return NotFound("File not found.");
            }

            var fileBytes = System.IO.File.ReadAllBytes(fileFullPath);
            var fileName = Path.GetFileName(fileFullPath);
            return File(fileBytes, "application/octet-stream", fileName);
        }
    
    

        [HttpGet]
        [Authorize]
        public IActionResult ApprovedTenant()
        {

			List<IndividualTenantDto> tenantList = _tenant.GetApprovedTenant();
			return View(tenantList);
		}

		public void SystemError(Exception ex)
		{
			_errorLogger.LogError(ex, GetControllerAndActionName(this));
			_toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.OperationFailed_Ex, null);

			ModelState.Clear();
		}

        
	}
}
