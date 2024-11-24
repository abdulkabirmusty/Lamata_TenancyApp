using Microsoft.AspNetCore.Identity;
using Tenant_App.Models.Constants;
using Tenant_App.Models.Domains.Account;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tenant_App.Models.DefaultRolesAndUserSeeds
{
    public static class DefaultUsers
    {

        public static async Task SeedBasicUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            ////Seed Default User
            var defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "deskofficer@lamata.com",
                FirstName = "deskofficer",
                LastName = "lamata",
                Email = "deskofficer@lamata.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@1");
                    await userManager.AddToRoleAsync(defaultUser, Roles.DESKOFFICER);
                }
            }
        }

        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin@gmail.com",
                FirstName = "Lamata",
                LastName = "Admin",
                Email = "Admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password@1");
                    await userManager.AddToRoleAsync(defaultUser, Roles.TENANT);
                    await userManager.AddToRoleAsync(defaultUser, Roles.ADMIN);
                }
                await roleManager.SeedClaimsForSuperAdmin();
            }
        }

        private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            await roleManager.AddPermissionClaim(adminRole, "tenant");
            await roleManager.AddPermissionClaim(adminRole, "dashboard");
            await roleManager.AddPermissionClaim(adminRole, "user");
            await roleManager.AddPermissionClaim(adminRole, "role");
            await roleManager.AddPermissionClaim(adminRole, "tenant");
            await roleManager.AddPermissionClaim(adminRole, "Approved_tenant");
            await roleManager.AddPermissionClaim(adminRole, "contract_type");
            await roleManager.AddPermissionClaim(adminRole, "property");
            //await roleManager.AddPermissionClaim(adminRole, "payment");
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}