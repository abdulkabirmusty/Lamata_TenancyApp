using Tenant_App.Models.Data;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Services.Contract.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenant_App.Services.Handler.Account
{
    public class RoleService : IRole
    {
        private readonly AppDbContext _context;
        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public string GetRoleId(string roleName)
        {
            return _context.Roles.FirstOrDefault(x => x.Name == roleName).Id;
        }
    }
}
