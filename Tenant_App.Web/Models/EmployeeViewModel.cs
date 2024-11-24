using Tenant_App.Models.DTOs;
using System.Collections.Generic;

namespace Tenant_App.Web.Models
{
    public class EmployeeViewModel
    {
        public PersonalDto PersonalDetails { get; set; }
        public OfficeDto OfficeDetails { get; set; }
        public List<FamilyDto> FamilyDetails { get; set; }
        public List<QualificationDto> QualificationDetails { get; set; }
        public BankDto BankDetails { get; set; }
    }
}
