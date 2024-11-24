using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.ContractTypeDtos;
using Tenant_App.Models.DataObjects.PaymentDtos;
using Tenant_App.Models.DataObjects.PropertyDtos;
using Tenant_App.Models.Domains.Payment;
using Tenant_App.Services.Contract.PaymentContract;
using Tenant_App.Services.Handler.PropertiesHandler;

namespace Tenant_App.Services.Handler.PaymentHandler
{
    public class PaymentService : IPaymentService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PaymentService> _logger;


        public PaymentService(AppDbContext context, ILogger<PaymentService> logger)
        {
            _context = context;
            _logger = logger;

        }


        public async Task<string> CreatePayment(string userId, decimal amount, string rrr, bool isSuccessful)
        {
            try
            {
                var user = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
                var property = _context.PropertyTenants.Where(x => x.UserID == userId).FirstOrDefault();

                Payment payment = new Payment
                {
                    UserId = userId,
                    FullName = user.FirstName +" "+ user.LastName,
                    PropertyName = property.PropertiesName,
                    PropertyAddress = property.PropertiesAddress,
                    Duration = property.PropertiesDuration,
                    ExpiryDate = property.expiryDate,
                    RRR = rrr,
                    Amount = amount,
                    PaymentDate = DateTime.Now,

                };

                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();

                return "Payment created successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating payment: {ex.Message}");
                return "An error occurred while creating the property";
                
            }
        }

        public List<PaymentDto> GetAllPayment()
        {
            try
            {
                var payment = _context.Payments
                    .Where(p => p.IsDeleted != true)
                    .Select(p => new PaymentDto
                    {
                        Id = p.Id,
                        FullName = p.FullName,
                        PropertyName = p.PropertyName,
                        PropertyAddress = p.PropertyAddress,
                        Duration = p.Duration,
                        ExpiryDate = p.ExpiryDate,
                        RRR = p.RRR,
                        Amount = p.Amount,
                        PaymentDate = p.PaymentDate,
                    })
                    .ToList();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving payment: {ex.Message}");
                return new List<PaymentDto>();
            }
        }

        public List<PaymentDto> GetAllPayment(string userId)
        {
            try
            {
                var payment = _context.Payments
                    .Where(p => p.IsDeleted != true && p.UserId == userId)
                    .Select(p => new PaymentDto
                    {
                        Id = p.Id,
                        FullName = p.FullName,
                        PropertyName = p.PropertyName,
                        PropertyAddress = p.PropertyAddress,
                        Duration = p.Duration,
                        ExpiryDate = p.ExpiryDate,
                        RRR = p.RRR,
                        Amount = p.Amount,
                        PaymentDate = p.PaymentDate,
                    })
                    .ToList();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving payment: {ex.Message}");
                return new List<PaymentDto>();
            }
        }

        public async Task<PaymentDto> GetPaymentById(Guid id)
        {
            try
            {
                var payment = _context.Payments
                    .Where(p => p.Id == id && p.IsDeleted != true)
                    .Select(p => new PaymentDto
                    {
                        Id = p.Id,
                        FullName = p.FullName,
                        PropertyName = p.PropertyName,
                        PropertyAddress = p.PropertyAddress,
                        Duration = p.Duration,
                        ExpiryDate = p.ExpiryDate,
                        RRR = p.RRR,
                        Amount = p.Amount,
                        PaymentDate = p.PaymentDate,
                    })
                    .FirstOrDefault();

                return payment;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving payment: {ex.Message}");
                return null;
            }
        }
    }
}
