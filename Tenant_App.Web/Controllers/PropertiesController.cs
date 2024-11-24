using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System.Linq.Dynamic.Core;
using Tenant_App.Models.Data;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Services.Contract.PropertiesContract;
using System.Linq;
using System;
using Tenant_App.Models.DataObjects.PropertyDtos;
using System.Security.Claims;
using Tenant_App.Models.Domains.PropertyDomain;
using System.Collections.Generic;
using Tenant_App.Models.DataObjects.Account;
using Tenant_App.Utilities.ExceptionUtility;
using System.Threading.Tasks;
using Tenant_App.Models.Constants;

namespace Tenant_App.Web.Controllers
{
    public class PropertiesController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IProperties _property;
        private readonly log4net.Core.ILogger _logger;
        private readonly IErrorLogger _errorLogger;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PropertiesController(AppDbContext appDbContext, IProperties property, ILogger<PropertiesController> logger, IErrorLogger errorLogger,
            IToastNotification toastNotification, IWebHostEnvironment hostingEnvironment)
        {
            _context = appDbContext;
            _property = property;
            _errorLogger = errorLogger;
            _toastNotification = toastNotification;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var property = _property.GetAllProperty();
            return View(property);
        }

        public IActionResult ViewProperty(Guid id)
        {
            var property = _context.Properties.Where(p => p.Id == id).FirstOrDefault();
            var properties = new PropertyDto
            {
                Id = property.Id,
                PropertyName = property.PropertyName,
                PropertyAddress = property.PropertyAddress,
                PropertyDesciption = property.PropertyDesciption,
                PropertyImage = property.PropertyImagePath,
                PropertyInformation = property.PropertyInformation,
                DurationAllowed = property.DurationAllowed,
                Amount = property.Amount,
                RemainingRoom = property.RemainingRoom,
                Size = property.Size,
                Dimension = property.Dimension,

            };

            return PartialView("_ViewProperty", properties);
        }

        [HttpGet]
        public async Task<IActionResult> Insert(Guid id)
        {
            // Fetch the user ID from the HttpContext
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                var errorResponse = new { success = false, message = "User ID not found." };
                return Json(errorResponse);
            }

            var property = _context.Properties.Where(p => p.Id == id).FirstOrDefault();

            if(property.RemainingRoom == 0)
            {
                _toastNotification.AddErrorToastMessage("There is no available at the moment", null);
                return Json(new { success = false, message = "No available rooms at the moment." });
            }

            var todayDate = DateTime.Now;
            var pendingRent = _context.PropertyTenants
                .Where(x =>x.PropertiesId == id && x.UserID == userId && x.expiryDate != todayDate && x.ApprovalStatus != 2).FirstOrDefault();
            
            if (pendingRent != null)
            {
                _toastNotification.AddErrorToastMessage($"There is still pending rent which will expire on {pendingRent.expiryDate.ToString("MM/dd/yyyy")}", null);
                return Json(new { success = false, message = "No available rooms at the moment." });
            }

            var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            
            var propertyTenant = new PropertyTenant
            {
                PropertiesId = property.Id,
                PropertiesName = property.PropertyName,
                PropertiesAddress = property.PropertyAddress,
                propertiesDescription = property.PropertyDesciption,
                CompanyName = user.FirstName + " " + user.LastName,
                PropertiesDuration = property.DurationAllowed,
                Amount = property.Amount,
                ApprovalStatus = 0,
                startDate = DateTime.Now,
                expiryDate = DateTime.Now.AddYears(1),
                UserID = userId,
                Size = property.Size,
                Dimension = property.Dimension,

            };

            // Add the property tenant to the database
            _context.PropertyTenants.Add(propertyTenant);

            property.RemainingRoom = property.RemainingRoom - 1;

            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage($"The Application for hostel {property.PropertyName} was successful. After Approval you can proceed to payment", null);

            //return RedirectToAction("ViewAmount", new { userId = userId, amount = property.Amount, fullName = $"{user.FirstName} {user.LastName}", email = user.Email });

            var response = new { success = true, message = "Property selected successfully and will be redirect for payment.", propertyTenant };
            return Json(response);


        }

        [HttpGet]
        public IActionResult MakeAmount(Guid id)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                var errorResponse = new { success = false, message = "User ID not found." };
                return Json(errorResponse);
            }

            var property = _context.Properties.Where(p => p.Id == id).FirstOrDefault();

            if (property.RemainingRoom == 0)
            {
                _toastNotification.AddErrorToastMessage("There is no available room at the moment", null);
                return RedirectToAction("Index");
            }

            var selectedProperty = _context.PropertyTenants.Where(t => t.UserID == userId && t.PropertiesId == id && t.IsPaid == false).FirstOrDefault();
            if (selectedProperty == null)
            {
                _toastNotification.AddErrorToastMessage("You are yet to apply for this Hostel, Apply before making payment", null);
                return RedirectToAction("Index");
            }

            if (selectedProperty.ApprovalStatus == 0)
            {
                _toastNotification.AddErrorToastMessage("Your Rent request is yet to be approve!", null);
                return RedirectToAction("Index");
            }
            
   //         var today = DateTime.Now;
			//if (selectedProperty.expiryDate != today)
			//{
			//	_toastNotification.AddErrorToastMessage("Your Rent is not expired yet", null);
			//	return RedirectToAction("Index");
			//}

			var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();

            var payment = new RegPaymentDto
            {
				UserId = userId,
				Amount = selectedProperty.Amount,
				FullName = user.FirstName + " " + user.LastName,
				Email = user.Email,
			};

            return View(payment);
        }

        [HttpGet]
        public IActionResult ViewPrpertiesOngoing()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = _context.Roles.FirstOrDefault(x => x.Name == Roles.ADMIN);
            var userRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == role.Id);

            List<PropertyTenant> propertyTenants;

            if (userRole != null)
            {
                propertyTenants = _context.PropertyTenants.OrderByDescending(x => x.startDate).ToList();
                ViewBag.IsAdmin = true;
            }
            else
            {
                propertyTenants = _context.PropertyTenants.Where(x => x.UserID == userId).OrderByDescending(x => x.startDate).ToList();
                ViewBag.IsAdmin = false;
            }

            // Pass the list of property tenants to the view
            return View(propertyTenants);
        }


        [HttpPost]
        public IActionResult UpdateApproval(Guid Id , string Comment, int ApprovalStatus, decimal Amount)
        {
            var tenant = _context.PropertyTenants.Find(Id);
            if (tenant != null)
            {
                tenant.Amount = Amount;
                tenant.Comment = Comment;
                tenant.ApprovalStatus = ApprovalStatus;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(ViewPrpertiesOngoing));
        }

    }
}
    