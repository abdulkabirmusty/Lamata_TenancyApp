using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class PassportDto
    {
        public IFormFile? PassportFile { get; set; }
    }
}
