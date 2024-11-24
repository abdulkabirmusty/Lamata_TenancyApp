using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DTOs;

namespace Tenant_App.Services.Contract.Frequency
{
	public interface IFrequencyService
	{
		Task<IEnumerable<FrequencyDto>> GetAllFrequenciesAsync();
		Task<FrequencyDto> GetFrequencyByIdAsync(Guid id);
		Task AddFrequencyAsync(FrequencyDto model);
		Task UpdateFrequencyAsync(Guid id, FrequencyViewModel model);
		Task DeleteFrequencyAsync(Guid id);
	}
}
