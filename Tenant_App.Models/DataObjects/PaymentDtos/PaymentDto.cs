using System;
using System.Collections.Generic;
using System.Text;
using Tenant_App.Models.Domains;

namespace Tenant_App.Models.DataObjects.PaymentDtos
{
    public class PaymentDto : BaseObjectDataIntegrity
    {
        public string UserId { get; set; }
        public string RRR { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public bool IsSuccessful { get; set; }
        public string FullName { get; set; }
        public string PropertyName { get; set; }
        public string PropertyAddress { get; set; }
        public string Duration { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
