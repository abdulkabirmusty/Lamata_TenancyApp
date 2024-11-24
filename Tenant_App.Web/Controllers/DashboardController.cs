using Microsoft.AspNetCore.Mvc;
using Tenant_App.Models.Data;
using Tenant_App.Models.DTOs.DashboardDto;
using System.Linq;
using System.Web.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using System.Security.Claims;

namespace Tenant_App.Web.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly AppDbContext _appDbContext;
        public DashboardController(AppDbContext appDbContext)
        {
                _appDbContext = appDbContext;
        }
        [HttpGet]
        [Authorize(Roles ="Admin,Human Resource")]
        public IActionResult Index()
        {
            

            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _appDbContext.Users.Where(x => x.Id == userId).FirstOrDefault();

            var userCount = _appDbContext.Users.Where(x => x.EmailConfirmed == false).Count();
            var approvedUserCount = _appDbContext.Users.Where(x => x.IsApproved == true).Count();
            var payment = _appDbContext.Payments.Where(x => x.IsSuccessful == true).Count();

            var Properties = _appDbContext.Properties.Sum(x => x.AvailableRoom + x.RemainingRoom);
            var availableProperty = _appDbContext.Properties.Sum(x => x.AvailableRoom);
            var remainingProperty = _appDbContext.Properties.Sum(x => x.RemainingRoom);

            ViewBag.FullName = user.FirstName + " " + user.LastName;
            ViewBag.Users = userCount;
            ViewBag.ApprovedUser = approvedUserCount;
            ViewBag.Payment = payment;
            ViewBag.Property = Properties;
            ViewBag.AvailableProperty = availableProperty;
            ViewBag.RemainingProperty = remainingProperty;

            return View();
        }
    }
}
