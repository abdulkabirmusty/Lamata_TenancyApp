using System;
using System.Collections.Generic;
using System.Text;
using Tenant_App.Models.Domains.TenantDocument;

namespace Tenant_App.Services.Contract.TenantDocumentContract
{
    public interface ITenantDocument
    {
        List<TenantDocumentType> GetAllDocumentTypes();
    }
}
