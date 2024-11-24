using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NToastNotify;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DTOs;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Services.Contract.ServiceCharge;

namespace Tenant_App.Web.Controllers
{
	public class ServiceChargeController : BaseController
	{
		private readonly AppDbContext _context;
		private readonly ILogger<ServiceChargeController> _logger;
		private readonly IServiceChargeService _serviceChargeService;
		private readonly IErrorLogger _errorLogger;
		private readonly IToastNotification _toastNotification;

		public ServiceChargeController(AppDbContext context, IServiceChargeService serviceChargeService,
									   ILogger<ServiceChargeController> logger, IErrorLogger errorLogger,
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
			try
			{
				var serviceCharges = await _context.ServiceCharges
					.Where(sc => sc.IsActive)
					.Select(sc => new ServiceChargeDto
					{
						Id = sc.Id,
						Amount = sc.Amount,
						CreatedDate = sc.CreatedDate,
						FrequencyId = sc.FrequencyId,
						ServiceTypeId = sc.ServiceTypeId,
						PropertyTypeId = sc.PropertyTypeId,
						PropertyName = _context.Properties
							.Where(p => p.Id == sc.PropertyTypeId && p.IsActive)
							.Select(p => p.PropertyName)
							.FirstOrDefault(),
						ServiceDescription = _context.serviceTypes
							.Where(st => st.Id == sc.ServiceTypeId && st.IsActive)
							.Select(st => st.Name)
							.FirstOrDefault(),
						FrequencyDescription = _context.Frequencies
							.Where(f => f.Id == sc.FrequencyId && f.IsActive)
							.Select(f => f.FrequencyType)
							.FirstOrDefault(),
						PropertyTypeName = _context.Properties
							.Where(pt => pt.Id == sc.PropertyTypeId && pt.IsActive)
							.Select(pt => pt.PropertyName)
							.FirstOrDefault()
					})
					.ToListAsync();

				var propertyTypes = await _context.Properties
					.Where(p => p.IsActive)
					.Select(p => new SelectListItem
					{
						Value = p.Id.ToString(),
						Text = p.PropertyName
					}).ToListAsync();

				var frequencies = await _context.Frequencies
					.Where(s => s.IsActive)
					.Select(s => new SelectListItem
					{
						Value = s.Id.ToString(),
						Text = s.FrequencyType.ToString()
					}).ToListAsync();

				var serviceTypes = await _context.serviceTypes
					.Where(s => s.IsActive)
					.Select(s => new SelectListItem
					{
						Value = s.Id.ToString(),
						Text = s.Name
					}).ToListAsync();

				ViewBag.PropertyTypes = propertyTypes;
				ViewBag.Frequencies = frequencies;
				ViewBag.ServiceTypes = serviceTypes;

				return View(serviceCharges);
			}
			catch (Exception ex)
			{
				// Log the exception
				_logger.LogError(ex, "An error occurred while fetching data for the Index view.");

				ViewBag.ErrorMessage = "An error occurred while loading data. Please try again later.";

				return View("Error");
			}
		}




		[HttpGet("ServiceCharge/Create")]
		public async Task<IActionResult> Create()
		{
			return PartialView("_AddServiceCharge");
		}

		[HttpPost("ServiceCharge/Create")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ServiceChargeDto serviceChargeDto)
		{
			if (!ModelState.IsValid)
			{
				_toastNotification.AddErrorToastMessage("Invalid data, please check your input.");
				return PartialView("_AddServiceCharge", serviceChargeDto);
			}

			try
			{
				await _serviceChargeService.AddServiceChargeAsync(serviceChargeDto);
				_toastNotification.AddSuccessToastMessage("Service charge added successfully.");
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error creating service charge: {ex.Message}");
				_toastNotification.AddErrorToastMessage("An error occurred while adding the service charge.");
				return PartialView("_AddServiceCharge", serviceChargeDto);
			}
		}

	}
}
