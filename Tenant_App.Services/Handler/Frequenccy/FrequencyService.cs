using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.Domains.ServiceType;
using Tenant_App.Models.DTOs;
using Tenant_App.Services.Contract.Frequency;
using Tenant_App.Services.Handler.PropertyHandler;

namespace Tenant_App.Services.Handler.Frequenccy
{
	public class FrequencyService : IFrequencyService
	{
		private readonly AppDbContext _context;
		private readonly ILogger<PropertyService> _logger;


		public FrequencyService(AppDbContext context, ILogger<PropertyService> logger)
		{
			_context = context;
			_logger = logger;

		}

		public async Task<IEnumerable<FrequencyDto>> GetAllFrequenciesAsync()
		{
			return await _context.Frequencies
				.Where(f => !(bool)f.IsDeleted && f.IsActive)
				.Select(f => new FrequencyDto
				{
					Id = f.Id,
					FrequencyDesc = f.FrequencyDesc,
					FrequencyType = f.FrequencyType,
					CreatedDate = f.CreatedDate,
					IsActive = f.IsActive
				})
				.ToListAsync();
		}

		public async Task<FrequencyDto> GetFrequencyByIdAsync(Guid id)
		{
			var frequency = await _context.Frequencies.FindAsync(id);
			if (frequency == null) return null;

			return new FrequencyDto
			{
				Id = frequency.Id,
				FrequencyDesc = frequency.FrequencyDesc,
				CreatedDate = frequency.CreatedDate,
				IsActive = frequency.IsActive
			};
		}

		public async Task AddFrequencyAsync(FrequencyDto model)
		{
			var frequency = new Frequency
			{
				Id = Guid.NewGuid(),
				FrequencyDesc = model.FrequencyDesc,
				FrequencyType = model.FrequencyType,
				CreatedDate = DateTime.UtcNow,
				IsActive = model.IsActive
			};
			_context.Frequencies.Add(frequency);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateFrequencyAsync(Guid id, FrequencyViewModel model)
		{
			var frequency = await _context.Frequencies.FindAsync(id);
			if (frequency == null) throw new Exception("Frequency not found");

			frequency.FrequencyDesc = model.FrequencyDesc;
			frequency.LastModified = DateTime.UtcNow;
			frequency.IsActive = model.IsActive;

			await _context.SaveChangesAsync();
		}

		public async Task DeleteFrequencyAsync(Guid id)
		{
			var frequency = await _context.Frequencies.FindAsync(id);
			if (frequency == null) throw new Exception("Frequency not found");

			frequency.IsDeleted = true;
			await _context.SaveChangesAsync();
		}
	}
}
