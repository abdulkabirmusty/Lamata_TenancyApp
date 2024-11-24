using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.CooperateTenantDomain
{
    public class CooperateTenant : BaseObject
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CooperateEmail { get; set; }
        public string MobilePhoneNo { get; set; }
        public string PersonalContact { get; set; }
        public string CACRegNo { get; set; }
        public string TIN { get; set; }
        public bool? Status { get; set; }
        public bool IsConsent { get; set; }
    }
}
