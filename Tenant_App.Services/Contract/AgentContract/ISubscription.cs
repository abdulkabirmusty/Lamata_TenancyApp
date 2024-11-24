using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.SubscriptionDtos;

namespace Tenant_App.Services.Contract.AgentContract
{
    public interface ISubscription
    {
        Task<string> CreateSubscription(SubscriptionDto subscriptionDto);

    }
}
