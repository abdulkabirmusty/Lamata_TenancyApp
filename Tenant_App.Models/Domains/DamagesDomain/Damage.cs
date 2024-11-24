using System;
using System.Collections.Generic;
using System.Text;
using Tenant_App.Models.Domains.Account;

namespace Tenant_App.Models.Domains.DamagesDomain
{
    public class Damage : BaseObject
    {
        public string FullName { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string PropertyId { get; set; }
		public string PropertyName { get; set; }
		public string Description { get; set; }
        public string DamageImagePath { get; set; }
        public string DamageType { get; set; }
        public DateTime ReportDate { get; set; }
        public string status { get; set; }
        public string Priority { get; set; }
        public string? AdminComment { get; set; }
    }
}
