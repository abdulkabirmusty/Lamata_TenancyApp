using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DataObjects.TenantDocumentDtos
{
    public class TenantDocumetDto
    {
        public Guid TenantDocumentTypeId { get; set; }
        public IFormFile TenantDocument { get; set; }
    }
}
