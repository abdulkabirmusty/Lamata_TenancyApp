using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.Domains.ServiceType;
using Tenant_App.Models.DTOs;
using Tenant_App.Services.Contract.ServiceCharge;
using Tenant_App.Services.Handler.PropertyHandler;

namespace Tenant_App.Services.Handler.ServiceChargeService
{
	public class ServiceChargeService : IServiceChargeService
	{
		private readonly AppDbContext _context;
		private readonly ILogger<PropertyService> _logger;


		public ServiceChargeService(AppDbContext context, ILogger<PropertyService> logger)
		{
			_context = context;
			_logger = logger;

		}
		public async Task<ServiceChargeDto> GetServiceChargeByIdAsync(Guid id)
		{
			try
			{
				var serviceCharge = await _context.ServiceCharges
					.Where(sc => sc.Id == id)
					.Select(sc => new ServiceChargeDto
					{
						Id = sc.Id,
						FrequencyId = sc.FrequencyId,
						PropertyTypeId = sc.PropertyTypeId,
						ServiceTypeId = sc.ServiceTypeId,
						ServiceDescription = sc.ServiceType.ServiceDesc,
						FrequencyDescription = sc.Frequency.FrequencyType,
						Amount = sc.Amount
					}).FirstOrDefaultAsync();

				return serviceCharge;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error retrieving service charge: {ex.Message}");
				return null;
			}
		}

		public async Task<IEnumerable<ServiceChargeDto>> GetAllServiceChargesAsync()
		{
			return await _context.ServiceCharges
				.Select(sc => new ServiceChargeDto
				{
					Id = sc.Id,
					ServiceDescription = sc.ServiceType.ServiceDesc,
					FrequencyDescription = sc.Frequency.FrequencyType,
					Amount = sc.Amount
				}).ToListAsync();
		}

		public async Task AddServiceChargeAsync(ServiceChargeDto serviceChargeDto)
		{
			var serviceCharge = new ServiceCharge
			{
				Id = Guid.NewGuid(),
				ServiceTypeId = serviceChargeDto.ServiceTypeId,
				PropertyTypeId = serviceChargeDto.PropertyTypeId,
				FrequencyId = serviceChargeDto.FrequencyId,

				Amount = serviceChargeDto.Amount
			};

			_context.ServiceCharges.Add(serviceCharge);
			await _context.SaveChangesAsync();
		}

		public async Task<ServiceChargePaymentDto> MakeServiceChargePaymentAsync(Guid serviceChargeId, string userId, Guid frequencyId)
		{
			ServiceChargePayment payment = null;

			try
			{
				var serviceCharge = await _context.ServiceCharges
					.Include(sc => sc.Frequency)
					.FirstOrDefaultAsync(sc => sc.Id == serviceChargeId);

				if (serviceCharge == null) return null;

				var frequency = await _context.Frequencies.FindAsync(frequencyId);
				decimal totalAmountToPay = serviceCharge.Amount * GetFrequencyMultiplier(frequency.FrequencyDesc);

				payment = new ServiceChargePayment
				{
					CustomerName = userId,
					ServiceTypeId = serviceCharge.ServiceTypeId,
					PropertyTypeId = serviceCharge.PropertyTypeId,
					FrequencyId = frequencyId,
					AmountToPay = totalAmountToPay,
					RRRCode = null,
					PaymentStatus = "Pending",
					PaymentDate = DateTime.Now,
					NextDueDate = DateTime.Now.AddDays(GetFrequencyDays(serviceCharge.Frequency.FrequencyDesc))
				};

				_context.serviceChargePayments.Add(payment);
				await _context.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
				Console.WriteLine($"Stack Trace: {ex.StackTrace}");
				if (ex.InnerException != null)
				{
					Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
					Console.WriteLine($"Inner Stack Trace: {ex.InnerException.StackTrace}");
				}
			}

			if (payment == null)
			{
				return null;
			}

			return new ServiceChargePaymentDto
			{
				Id = payment.Id,
				AmountToPay = payment.AmountToPay,
				RRRCode = payment.RRRCode,
				PaymentStatus = payment.PaymentStatus,
				PaymentDate = payment.PaymentDate
			};
		}

		public async Task<bool> UpdatePaymentConfirmation(string userId, string rrr, decimal amount)
		{
			try
			{
				var payment = await _context.serviceChargePayments
					.Where(p => p.CustomerName == userId && p.PaymentStatus == "Pending")
					.OrderByDescending(p => p.CreatedDate)
					.FirstOrDefaultAsync();


				if (payment == null)
				{
					//_errorLogger.LogWarning($"No pending payment found for UserId: {userId}, Amount: {amount}");
					return false;
				}

				payment.RRRCode = rrr;
				payment.PaymentStatus = "Successful";
				payment.PaymentDate = DateTime.Now;
				payment.LastModified = DateTime.Now;
				payment.ModifiedBy = userId;

				_context.serviceChargePayments.Update(payment);
				await _context.SaveChangesAsync();

				return true;
			}
			catch (Exception ex)
			{
				// Log the exception for debugging
				//_errorLogger.LogError(ex, $"Error updating payment confirmation for UserId: {userId}, RRR: {rrr}, Amount: {amount}");
				return false;
			}
		}


		//public async Task<ServiceChargePaymentDto> MakeServiceChargePaymentAsync(Guid serviceChargeId, string customerName, Guid frequencyId)
		//{
		//    try
		//    {
		//        var serviceCharge = await _context.ServiceCharges
		//            .Include(sc => sc.Frequency)
		//            .FirstOrDefaultAsync(sc => sc.Id == serviceChargeId);

		//        if (serviceCharge == null) return null;

		//        decimal totalAmountToPay = serviceCharge.Amount * GetFrequencyMultiplier(serviceCharge.Frequency.FrequencyDesc);
		//        var payment = new ServiceChargePayment
		//        {
		//            //Id = Guid.NewGuid(),
		//            CustomerName = customerName,
		//            ServiceTypeId = serviceCharge.ServiceTypeId,
		//            PropertyTypeId = serviceCharge.PropertyTypeId,
		//            FrequencyId = frequencyId,
		//            AmountToPay = totalAmountToPay,
		//            RRRCode = GenerateRRRCode(),
		//            PaymentStatus = "Pending",
		//            PaymentDate = DateTime.Now,
		//            NextDueDate = DateTime.Now.AddDays(GetFrequencyDays(serviceCharge.Frequency.FrequencyDesc))
		//        };

		//        _context.serviceChargePayments.Add(payment);
		//        await _context.SaveChangesAsync();

		//        return new ServiceChargePaymentDto
		//        {
		//            Id = payment.Id,
		//            CustomerName = payment.CustomerName,
		//            ServiceDescription = serviceCharge.ServiceType.ServiceDesc,
		//            FrequencyDescription = serviceCharge.Frequency.FrequencyDesc,
		//            AmountToPay = payment.AmountToPay,
		//            RRRCode = payment.RRRCode,
		//            PaymentStatus = payment.PaymentStatus,
		//            PaymentDate = payment.PaymentDate,
		//            NextDueDate = payment.NextDueDate
		//        };
		//    }
		//    catch (Exception ex)
		//    {
		//        _logger.LogError($"Error making service charge payment: {ex.Message}");
		//        return null;
		//    }
		//}

		public async Task<IEnumerable<UserServiceChargeDto>> GetServiceChargesForUserAsync(string userId)
		{
			var query = from pt in _context.PropertyTenants
						join sc in _context.ServiceCharges on pt.PropertiesId equals sc.PropertyTypeId
						join st in _context.serviceTypes on sc.ServiceTypeId equals st.Id
						join freq in _context.Frequencies on sc.FrequencyId equals freq.Id
						where pt.UserID == userId && sc.IsActive
						select new
						{
							ServiceChargeId = sc.Id,
							PropertyId = pt.PropertiesId,
							PropertiesName = pt.PropertiesName,
							PropertiesAddress = pt.PropertiesAddress,
							Amount = sc.Amount,
							UserId = pt.UserID,
							ServiceTypeName = st.Name,
							Tenure = freq.FrequencyType,
							Payments = (from scp in _context.serviceChargePayments
										where scp.PropertyTypeId == sc.PropertyTypeId
											  && scp.ServiceTypeId == sc.ServiceTypeId
											  && scp.FrequencyId == sc.FrequencyId
										orderby scp.PaymentDate descending
										select scp).FirstOrDefault()
						};

			var result = await query.ToListAsync();
			return result.Select(x => new UserServiceChargeDto
			{
				ServiceChargeId = x.ServiceChargeId,
				PropertyId = x.PropertyId,
				PropertiesName = x.PropertiesName,
				PropertiesAddress = x.PropertiesAddress,
				Amount = x.Amount,
				UserId = x.UserId,
				PaymentStatus = x.Payments?.PaymentStatus ?? "Unpaid",
				ServiceTypeName = x.ServiceTypeName,
				Tenure = x.Tenure
			});
		}



		private int GetFrequencyMultiplier(string frequency)
		{
			return frequency switch
			{
				"Monthly" => 1,
				"Quarterly" => 3,
				"Yearly" => 12,
				_ => 1
			};
		}

		private int GetFrequencyDays(string frequency)
		{
			return frequency switch
			{
				"Monthly" => 30,
				"Quarterly" => 90,
				"Yearly" => 365,
				_ => 30
			};
		}

		private string GenerateRRRCode()
		{
			return Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
		}
	}

}
