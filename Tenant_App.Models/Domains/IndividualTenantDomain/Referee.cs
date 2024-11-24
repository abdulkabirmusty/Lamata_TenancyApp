using Tenant_App.Models.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.IndividualTenantDomain
{
    public class Referee : BaseObject
    {
        public string FullName { get; set; }
        public string Relationship { get; set; }
        public string MobileNo { get; set; }
        public string SignaturePath { get; set; }
        public Guid IndividualTenantId { get; set; }
    }
}
