using System;

namespace Tenant_App.Models.Domains.Account
{
    public class RolePermission : BaseObject
    {
        public Guid PermissionId { get; set; }
        public string RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
