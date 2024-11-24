using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.SubscriptionDtos;
using Tenant_App.Models.Domains.SubscriptionDomain;
using Tenant_App.Services.Contract.AgentContract;
using Tenant_App.Services.Handler.PropertyHandler;

namespace Tenant_App.Services.Handler.AgentHandlers
{
    public class SubscriptionService : ISubscription
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SubscriptionService> _logger;


        public SubscriptionService(AppDbContext context, ILogger<SubscriptionService> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<string> CreateSubscription(SubscriptionDto subscriptionDto)
        {
            string status = "";
            try
            {
                var subscribe = new Subscription
                {
                    FullName = subscriptionDto.FullName,
                    userId = subscriptionDto.userId,
                    RRR = subscriptionDto.RRR,
                    Amount = subscriptionDto.Amount,
                    PaymentDate = subscriptionDto.PaymentDate,
                    IsSuccessful = subscriptionDto.IsSuccessful,
                    IsExpired = false,
                    StartDate = DateTime.Now,
                    ExpiryDate = DateTime.Now.AddYears(1),
                };

                _context.Subscriptions.Add(subscribe);
                await _context.SaveChangesAsync();

                return "Subscription was successful";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
