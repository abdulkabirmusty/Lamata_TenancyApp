using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.EmployeeProfile
{
    public class BankDetail
    {
        public Guid Id { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public string? BankName { get; set; }
        public string? Ippis { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
    }

}
