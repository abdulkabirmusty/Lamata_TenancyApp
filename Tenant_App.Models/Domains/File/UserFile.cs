using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.File
{
    public class UserFile
    {
        public Guid Id { get; set; }
        public string FilePath { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
