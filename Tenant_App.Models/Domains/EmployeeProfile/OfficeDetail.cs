using Microsoft.CodeAnalysis;
using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.EmployeeProfile
{
    public class OfficeDetail
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string LocationName { get; set; }
        public string LevelName { get; set; }
        public string RankName { get; set; }
        public string ConRaise { get; set; }


        public DateTime? DateOfEmployment { get; set; }
        public DateTime? ISTAppointmentDate { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public DateTime? PresentAppointmentDate { get; set; }

        public string Ippis { get; set; }
        public string UserId { get; set; }

        public User User { get; set; }
       

    }
}
