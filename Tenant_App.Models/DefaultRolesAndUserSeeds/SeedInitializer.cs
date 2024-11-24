using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Tenant_App.Models.Data;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Utilities.Document;
using Tenant_App.Utilities.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenant_App.Models.DefaultRolesAndUserSeeds
{
    public static class SeedInitializer
    {
        public static async Task SeedAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                UserManager<User> userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                RoleManager<IdentityRole> roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                AppDbContext context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();

                await DefaultRoles.SeedAsync(userManager, roleManager);
                await DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
               await DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);


                //var enrollmentStatus = new EnrollmentStatus();
                //var nominaleRoll = new NominalRoll();
                //nominaleRoll.IPPISNO = "test12";
                //nominaleRoll.Firstname = "AdminUser";
                //enrollmentStatus.IPPISNO = "test12";
                //enrollmentStatus.Status = EnrollStatus.InProgress.ToString();
                //if(context.NominalRolls.Where(p=>p.IPPISNO == "test12").Count() == 0)
                //{
                //    await context.NominalRolls.AddAsync(nominaleRoll);
                //    await context.EnrollmentStatuses.AddAsync(enrollmentStatus);
                //    await context.SaveChangesAsync();
                //}
                
            }
        }

    }
}
