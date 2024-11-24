using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class EmployeeQueryDto
    {
        public string Ippis { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string Grade { get; set; }
    }
}
