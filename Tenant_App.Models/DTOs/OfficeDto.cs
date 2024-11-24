using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class OfficeDto
    {
        public Guid? Id { get; set; }
        public string? Designation { get; set; }
		public string? IPPISNo { get; set; }
		public string? Department { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public string? Level { get; set; }
        public string? Rank { get; set; }
        public DateTime? ISTAppointmentDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? PresentAppointmentDate { get; set; }
        public string? Conr { get; set; } // Unknown column, adjust as needed
        public string? Location { get; set; }
        public string? UserId { get; set; }
    }

}
