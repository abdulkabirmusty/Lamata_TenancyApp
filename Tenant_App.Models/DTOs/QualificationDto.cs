using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class QualificationDto
    {
        public Guid? Id { get; set; }
        public string? IPPISNo { get; set; }
        public string? Programme { get; set; }
        public string? DateObtained { get; set; }
        public string? DegreeObtained { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public string? UserId { get; set; }
    }

}
