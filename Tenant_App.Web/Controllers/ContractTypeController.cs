using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.ContractTypeDtos;
using Tenant_App.Services.Contract.ContractTypeContract;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Utilities.ExceptionUtility;

namespace Tenant_App.Web.Controllers
{
    public class ContractTypeController : BaseController
    {
        private readonly AppDbContext _context;
        private readonly log4net.Core.ILogger _logger;
        private readonly IContractType _contractType;
        private readonly IErrorLogger _errorLogger;
        private readonly IToastNotification _toastNotification;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ContractTypeController(AppDbContext appDbContext, IContractType contractType, ILogger<ContractTypeController> logger, IErrorLogger errorLogger,
            IToastNotification toastNotification, IWebHostEnvironment hostingEnvironment)
        {
            _context = appDbContext;
            _contractType = contractType;
            _errorLogger = errorLogger;
            _toastNotification = toastNotification;
            _hostingEnvironment = hostingEnvironment;
        }


        public IActionResult Index()
        {
            var contractType = _contractType.GetAllContractType();
            return View(contractType);
        }

        [HttpGet("ContractType/Create")]
        public IActionResult Create() 
        {
            return PartialView("_AddContractType");
        }

        [HttpPost("ContractType/Create")]
        public async Task< IActionResult> Create(ContractTypeDto model)
        {
            try
            {
                model.CreatedBy = CurrentUser.UserId;
                model.CreatedDate = DateTime.Now;
                model.IsActive = true;

                var response = await _contractType.CreateContractType(model);
                //if (!string.IsNullOrEmpty(response) && response != ResponseErrorMessageUtility.SuccessfulAndUpdated)
                //{
                //    _toastNotification.AddWarningToastMessage(response, null);
                //    return RedirectToAction(nameof(Index));
                //}
                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.Succesful, null);

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return systemError(ex);
            }

        }

        [HttpGet("ContractType/Edit")]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var response = await _contractType.GetById(Id);
            return PartialView("_EditContractType", response);
        }

        [HttpPost("ContractType/Edit")]
        public async Task<IActionResult> Edit(ContractTypeDto model, Guid id)
        {
            try
            {
                model.ModifiedBy = CurrentUser.UserId;
                model.LastModified = DateTime.Now;

                var response = await _contractType.UpdateContractType(model, id);
                
                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.UpdateRecord, null);

                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return systemError(ex);
            }

        }

        [HttpGet("ContractType/Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var response = await _contractType.GetById(Id);
            return PartialView("_DeleteContractType", response);
        }

        [HttpPost("ContractType/Delete")]
        public async Task<IActionResult> Delete(ContractTypeDto model, Guid id)
        {
            try
            {
                model.ModifiedBy = CurrentUser.UserId;
                model.LastModified = DateTime.Now;
                //model.IsActive = false;

                var response = await _contractType.DeleteContractType(id);

                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.DeleteOperation, null);

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
