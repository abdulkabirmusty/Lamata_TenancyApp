using System;
using System.Collections.Generic;
using System.Text;
using Tenant_App.Models.Domains.CooperateTenantDomain;

namespace Tenant_App.Models.Domains.TenantDocument
{
    public class TenantDocument : BaseObject
    {
        public string FileName { get; set; }
        public string DocumentPath { get; set; }
        public Guid ComporateTenantId { get; set; }
        public Guid DocumentTypeId { get; set; }
        public virtual CooperateTenant CooperateTenant { get; set; }
        public virtual TenantDocumentType TenantDocumentType { get; set; }
    }

    public class TenantDocumentType : BaseObject
    {
        public string Name { get; set; }
    }
}
