using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class BankDto
    {
        public Guid? Id { get; set; }
        public string? IPPISNo { get; set; }
        public string? AccountNumber { get; set; }
        public string? AccountName { get; set; }
        public string? BankName { get; set; }
        public string? UserId { get; set; }
    }

}
