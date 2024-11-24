using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DataObjects.SubscriptionDtos
{
    public class SubscriptionDto
    {
        public Guid Id { get; set; }
        public string userId { get; set; }
        public string FullName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RRR { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public bool IsSuccessful { get; set; }
        public bool IsExpired { get; set; }
        public bool IsActive { get; set; }
    }
}
