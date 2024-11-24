using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DataObjects.DashboardViewModel
{
    public class DashboardViewModel
    {
        public int TotalUser { get; set; }
        public int TotalApprovedUsers { get; set; }
        public int TotalPaidUsers { get; set; }
    }
}
