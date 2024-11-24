using Tenant_App.Models.Domains.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Services.Contract.Account
{
    public interface IPermission
    {
        List<Permission> GetPermissionsByRoleId(string roleId);
    }
}
