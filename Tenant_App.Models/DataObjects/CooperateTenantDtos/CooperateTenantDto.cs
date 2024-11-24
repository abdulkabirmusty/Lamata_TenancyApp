using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DataObjects.CooperateTenantDtos
{
    public class CooperateTenantDto
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CooperateEmail { get; set; }
        public string Address { get; set; }
        public string MobilePhoneNo { get; set; }
        public string PersonalContact { get; set; }
		public string CACRegNo { get; set; }
		public string TIN { get; set; }
		public bool? Status { get; set; }
		public bool IsConsent { get; set; }
		public string FormC07 { get; set; }
        public string BankReference { get; set; }
        public string DirectorProfile { get; set; }
        public string DocumentPath { get; set; }
        public string DocumentPathRef { get; set; }
        public string DocumentPathRefDir { get; set; }
    }
}
