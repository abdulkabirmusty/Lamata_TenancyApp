using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DTOs;

namespace Tenant_App.Services.Contract.ServiceCharge
{
	public interface IServiceChargeService
	{
		Task<ServiceChargeDto> GetServiceChargeByIdAsync(Guid id);
		Task<IEnumerable<ServiceChargeDto>> GetAllServiceChargesAsync();
		Task AddServiceChargeAsync(ServiceChargeDto serviceChargeDto);

		Task<IEnumerable<UserServiceChargeDto>> GetServiceChargesForUserAsync(string userId);
		Task<bool> UpdatePaymentConfirmation(string userId, string rrr, decimal amount);
		Task<ServiceChargePaymentDto> MakeServiceChargePaymentAsync(Guid serviceChargeId, string customerName, Guid frequencyId);
	}
}
