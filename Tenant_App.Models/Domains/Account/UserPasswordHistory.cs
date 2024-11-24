using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenant_App.Models.Domains.Account
{
    public class UserPasswordHistory : BaseObject
    {
        public string UserId { get; set; }
        public string HashPassword { get; set; }

       public string PasswordSalt { get; set; }
    }
}
