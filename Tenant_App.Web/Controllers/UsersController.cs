using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tenant_App.Models.Domains.Account;
using System.Linq;
using System.Threading.Tasks;

namespace Tenant_App.Web.Controllers
{

    // This is for the index of the user roles management view
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var allUsersExceptCurrentUser = await _userManager.Users.Where(a => a.Id != currentUser.Id && a.IsDeleted == false && a.Email != "test12").ToListAsync();
            
            return View(allUsersExceptCurrentUser);
        }

        public async Task<IActionResult> ActivateDeactivate(string userId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var user = await _userManager.Users.Where(a => a.Id == userId).FirstOrDefaultAsync();
            if(user.IsActive)
            {
                user.IsActive = false;

            }
            else
            {
                user.IsActive = true;

            }
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteUser(string userId)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);
            var user = await _userManager.Users.Where(a => a.Id == userId).FirstOrDefaultAsync();
            user.IsDeleted = true;
            await _userManager.UpdateAsync(user);

            return RedirectToAction("Index");
        }


    }
}