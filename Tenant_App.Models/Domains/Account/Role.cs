using Microsoft.AspNetCore.Identity;

namespace Tenant_App.Models.Domains.Account
{
    public class Role : IdentityRole<string>
    {
        public string RoleDescription { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
