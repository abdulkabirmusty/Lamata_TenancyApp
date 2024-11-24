using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class WorkExperienceDto
    {
        public Guid? Id { get; set; }
        public string? Employer { get; set; }
        public string? PositionHeld { get; set; }
        public string? Level { get; set; }
        public string? JobDescription { get; set; }
        public string? EmployerPhoneNo { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }

}
