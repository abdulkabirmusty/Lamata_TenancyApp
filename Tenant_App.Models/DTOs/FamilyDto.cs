using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class FamilyDto
    {
        public Guid Id { get; set; }
		public string? IPPISNo { get; set; }
		public string Name { get; set; }
		public string Phone { get; set; }
		public string Relationship { get; set; }
		public bool Dependent { get; set; }
		public bool NextOfKin { get; set; }
		public bool IsDeleted { get; set; } = false;

        public string UserId { get; set; }
    }

}
