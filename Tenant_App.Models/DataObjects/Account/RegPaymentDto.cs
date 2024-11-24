using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DataObjects.Account
{
	public class RegPaymentDto
	{
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
    }
}
