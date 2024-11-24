using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tenant_App.Models.DefaultRolesAndUserSeeds;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Models.RoleAndPermissionViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tenant_App.Web.Controllers
{
    [Authorize(Roles = "Admin,Human Resource")]
    public class UserRolesController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(string userId)
        {
            var viewModel = new List<UserRolesViewModel>();
            var user = await _userManager.FindByIdAsync(userId);
            foreach (var role in _roleManager.Roles.ToList())
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleName = role.Name,
                    
                    
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                viewModel.Add(userRolesViewModel);
            }
            var model = new ManageUserRolesViewModel()
            {
                UserId = userId,
                UserRoles = viewModel,
                UserName = $"{user.FirstName} {user.LastName}  With IPPIS: {user.Email}" 
            };

            return View(model);
        }

        public async Task<IActionResult> Update(string id, ManageUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            result = await _userManager.AddToRolesAsync(user, model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
            var currentUser = await _userManager.GetUserAsync(User);
            await _signInManager.RefreshSignInAsync(currentUser);
            await DefaultUsers.SeedSuperAdminAsync(_userManager, _roleManager);
            return RedirectToAction("Index", new { userId = id });
        }
    }
}