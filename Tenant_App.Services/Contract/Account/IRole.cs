using Tenant_App.Models.Domains.Account;

namespace Tenant_App.Services.Contract.Account
{
    public interface IRole
    {
        string GetRoleId(string roleName);
    }
}
