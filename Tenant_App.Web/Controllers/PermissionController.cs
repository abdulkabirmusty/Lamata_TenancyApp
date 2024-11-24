using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tenant_App.Models.Constants;
using Tenant_App.Models.RoleAndPermissionViewModels;
using System.Collections.Generic;
using Tenant_App.Models.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace Tenant_App.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PermissionController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public PermissionController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<ActionResult> Index(string roleId)
        {
            
            try
            {
                var model = new PermissionViewModel();
                var allPermissions = new List<RoleClaimsViewModel>();
                allPermissions.GetPermissions(typeof(Permissions.Tenant), roleId);
                allPermissions.GetPermissions(typeof(Permissions.Dashboard), roleId);
                allPermissions.GetPermissions(typeof(Permissions.Role), roleId);
                allPermissions.GetPermissions(typeof(Permissions.User), roleId);
                allPermissions.GetPermissions(typeof(Permissions.Contract_Type), roleId);
                allPermissions.GetPermissions(typeof(Permissions.Property), roleId);
                var role = await _roleManager.FindByIdAsync(roleId);
                model.RoleId = roleId;
                model.RoleName = role.Name;
                var claims = await _roleManager.GetClaimsAsync(role);
                var allClaimValues = allPermissions.Select(a => a.Value).ToList();
                var roleClaimValues = claims.Select(a => a.Value).ToList();
                var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
                foreach (var permission in allPermissions)
                {
                    if (authorizedClaims.Any(a => a == permission.Value))
                    {
                        permission.Selected = true;
                    }
                }
                model.RoleClaims = allPermissions;
                return View(model);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        public async Task<IActionResult> Update(PermissionViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            var claims = await _roleManager.GetClaimsAsync(role);
            //foreach (var claim in claims)
            //{
            //    await _roleManager.RemoveClaimAsync(role, claim);
            //}
            
            var selectedClaims = model.RoleClaims.Where(a => a.Selected).ToList();
            foreach (var claim in selectedClaims)
            {
                if (!claims.Any(a => a.Value == claim.Value))
                {
                    await _roleManager.AddPermissionClaim(role, claim.Value);

                }
            }
            return RedirectToAction("Index", new { roleId = model.RoleId });
        }
    }
}
