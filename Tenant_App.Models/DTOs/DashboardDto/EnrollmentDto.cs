using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs.DashboardDto
{
    public class EnrollmentDto
    {
        public int Completed { get; set; }
        public int InProgress { get; set; }
        public int Pending { get; set; }
    }
}
