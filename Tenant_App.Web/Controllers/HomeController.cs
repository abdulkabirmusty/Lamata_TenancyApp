using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Tenant_App.Models.Data;
using Tenant_App.Services.Contract.EmailMessaging;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Web.Controllers;
using NToastNotify;
//using System.Web.Mvc;

namespace Tenant_App.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToastNotification _toastNotification;
        private readonly IErrorLogger _errorLogger;
        private readonly IEmailMessaging _emailManager;
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;



        public HomeController(ILogger<HomeController> logger, IToastNotification toastNotification, IEmailMessaging emailManager,
             IConfiguration configuration, AppDbContext context)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _emailManager = emailManager;
            _context = context;
            _configuration = configuration;



        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult TenantType()
        {
            return View();
        }
    }
}
