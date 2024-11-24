using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.SubscriptionDomain
{
    public class Subscription : BaseObject
    {
        public string userId { get; set; }
        public string FullName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RRR { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsSuccessful { get; set; }
        public bool IsExpired { get; set; }

    }
}
