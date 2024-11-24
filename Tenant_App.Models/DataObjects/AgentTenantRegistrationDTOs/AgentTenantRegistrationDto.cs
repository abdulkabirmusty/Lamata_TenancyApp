using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DataObjects.AgentTenantRegistrationDTOs
{
    public class AgentTenantRegistrationDto
    {
        public Guid Id { get; set; }
        public string AgentName { get; set; }
        public string TenantName { get; set; }
        public string TenantEmail { get; set; }
        public string TenantPhoneNumber { get; set; }
        public string PropertiesName { get; set; }
        public string PropertiesAddress { get; set; }
        public string propertiesDescription { get; set; }
        public string PropertiesDuration { get; set; }
        public decimal Amount { get; set; }
        public string CompanyName { get; set; }
        public int ApprovalStatus { get; set; }
        public DateTime startDate { get; set; }
        public DateTime expiryDate { get; set; }
        public string PropertiesId { get; set; }
        public string UserID { get; set; }
        public string Comment { get; set; }
    }
}
