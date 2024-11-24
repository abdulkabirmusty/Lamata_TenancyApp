using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.PaymentDtos;
using Tenant_App.Models.Domains.Payment;

namespace Tenant_App.Services.Contract.PaymentContract
{
	public interface IPaymentService
	{
        Task<string> CreatePayment(string userId, decimal amount, string rrr, bool isSuccessful);
        public List<PaymentDto> GetAllPayment();
        public List<PaymentDto> GetAllPayment(string userId);
        Task<PaymentDto> GetPaymentById(Guid id);
	}
}
