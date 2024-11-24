using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.EmployeeProfile
{
    public class FamilyDetail
    {
        public Guid Id { get; set; }
         public string Name { get; set; }
         public string Phone { get; set; }
         public string Relationship { get; set; }
         public bool Dependent { get; set; }
         public bool NextOfKin { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string Ippis { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
