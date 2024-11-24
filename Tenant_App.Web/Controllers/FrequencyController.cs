using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tenant_App.Models.DTOs;
using Tenant_App.Services.Contract.Frequency;

namespace Tenant_App.Web.Controllers
{
	public class FrequencyController : Controller
	{
		private readonly IFrequencyService _frequencyService;

		public FrequencyController(IFrequencyService frequencyService)
		{
			_frequencyService = frequencyService;
		}

		public async Task<IActionResult> Index()
		{
			var frequencies = await _frequencyService.GetAllFrequenciesAsync();

			foreach (var frequency in frequencies)
			{
				frequency.FrequencyTypeName = Enum.GetName(typeof(FrequencyType), frequency.FrequencyType);
			}

			return View(frequencies);

		}

		public IActionResult Create()
		{
			var model = new FrequencyDto();

			ViewBag.FrequencyTypes = new SelectList(Enum.GetValues(typeof(FrequencyType)).Cast<FrequencyType>().Select(e => new SelectListItem
			{
				Value = ((int)e).ToString(),
				Text = e.ToString()
			}), "Value", "Text");

			return PartialView("_AddFrequency", model);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(FrequencyDto model)
		{
			model.IsActive = true;
			if (ModelState.IsValid)
			{
				await _frequencyService.AddFrequencyAsync(model);

				return RedirectToAction(nameof(Index));
			}

			return PartialView("_AddFrequency", model);
		}


		public async Task<IActionResult> Edit(Guid id)
		{
			var frequency = await _frequencyService.GetFrequencyByIdAsync(id);
			if (frequency == null)
			{
				return NotFound();
			}
			var model = new FrequencyViewModel
			{
				FrequencyDesc = frequency.FrequencyDesc,
				IsActive = frequency.IsActive
			};
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, FrequencyViewModel model)
		{
			if (ModelState.IsValid)
			{
				await _frequencyService.UpdateFrequencyAsync(id, model);
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			var frequency = await _frequencyService.GetFrequencyByIdAsync(id);
			if (frequency == null)
			{
				return NotFound();
			}
			return View(frequency);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			await _frequencyService.DeleteFrequencyAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}

