using Tenant_App.Models.Domains.EmployeeProfile;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class EmployeeViewDto
    {
        public OfficeDetail? OfficeDetail { get; set; }
        public PersonalDetail? PersonalDetail { get; set; }
        public ICollection< FamilyDetail>? FamilyDetail { get; set; }
        public ICollection <QualificationDetail>? QualificationDetail { get; set; }
        public BankDetail? BankDetail { get; set; }
    }
}
