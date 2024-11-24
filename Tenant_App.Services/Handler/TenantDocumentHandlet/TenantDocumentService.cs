using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tenant_App.Models.Data;
using Tenant_App.Models.Domains.TenantDocument;
using Tenant_App.Services.Contract.TenantDocumentContract;

namespace Tenant_App.Services.Handler.TenantDocumentHandlet
{
    public class TenantDocumentService : ITenantDocument
    {
        private readonly AppDbContext _context;

        public TenantDocumentService(AppDbContext context)
        {
            _context = context;
        }

        public List<TenantDocumentType> GetAllDocumentTypes()
        {
            return _context.TenantDocumentTypes.ToList();
        }
    }
}
