using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tenant_App.Models.DataObjects.DocumentDTOs
{
	
    public class DocumentDTO
    {
        public Guid DocumentTypeId { get; set; }
        public IFormFile Document {  get; set; }
    }

}
