using Microsoft.AspNetCore.Identity;
using Tenant_App.Models.Constants;
using Tenant_App.Models.Domains.Account;
using System.Threading.Tasks;

namespace Tenant_App.Models.DefaultRolesAndUserSeeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.ADMIN));
            await roleManager.CreateAsync(new IdentityRole(Roles.TENANT));
            //await roleManager.CreateAsync(new IdentityRole(Roles.BASICUSER));
        }
    }
}