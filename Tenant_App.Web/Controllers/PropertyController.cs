using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System.Threading.Tasks;
using System;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.ContractTypeDtos;
using Tenant_App.Models.Domains.ContractTypeDomain;
using Tenant_App.Services.Contract.ContractTypeContract;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Services.Contract.PropertyContract;
using Tenant_App.Utilities.ExceptionUtility;
using Tenant_App.Models.DataObjects.PropertyDtos;

namespace Tenant_App.Web.Controllers
{
    public class PropertyController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly IProperty _property;
        private readonly log4net.Core.ILogger _logger;
        private readonly IErrorLogger _errorLogger;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PropertyController(AppDbContext appDbContext, IProperty property, ILogger<PropertyController> logger, IErrorLogger errorLogger,
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

        [HttpGet("Property/Create")]
        public IActionResult Create()
        {
            return PartialView("_AddProperty");
        }

        [HttpPost("Property/Create")]
        public async Task<IActionResult> Create(PropertyRegDto model)
        {
            try
            {
                model.CreatedBy = CurrentUser.UserId;
                model.CreatedDate = DateTime.Now;
                model.IsActive = true;

                var response = await _property.CreateProperty(model);
                
                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.Succesful, null);

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return systemError(ex);
            }

        }

        [HttpGet("Property/Edit")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var response = await _property.GetPropertyById(Id);
            return PartialView("_EditProperty", response);
        }

        [HttpPost("Property/Edit")]
        public async Task<IActionResult> Edit(PropertyRegDto model, Guid id)
        {
            try
            {
                model.ModifiedBy = CurrentUser.UserId;
                model.LastModified = DateTime.Now;

                var response = await _property.UpdateProperty(model, id);

                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.UpdateRecord, null);

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return systemError(ex);
            }

        }

        [HttpGet("Property/Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var response = await _property.GetPropertyById(Id);
            return PartialView("_DeleteProperty", response);
        }

        [HttpPost("Property/Delete")]
        public async Task<IActionResult> Delete(PropertyDto model, Guid id)
        {
            try
            {
                model.ModifiedBy = CurrentUser.UserId;
                model.LastModified = DateTime.Now;
                //model.IsActive = false;

                var response = await _property.DeleteProperty(id);

                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.DeleteOperation, null);

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return systemError(ex);
            }

        }

        [HttpPost("Property/ActivateDeactivate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateDeactivate(PropertyDto obj)
        {
            bool response = await _property.UpdateStatus(obj.Id);

            if (response == false)
            {
                _toastNotification.AddWarningToastMessage(ResponseErrorMessageUtility.UpdateStatusFail, null);

                return RedirectToAction(nameof(Index));
            }

            _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.UpdateStatusSuccess, null);

            ModelState.Clear();

            return RedirectToAction(nameof(Index));
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
