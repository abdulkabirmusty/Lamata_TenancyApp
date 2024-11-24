using log4net.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Tenant_App.Models;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Web.Filters;
using Abp.Runtime.Security;
using Microsoft.AspNet.Identity;
using System;

namespace Tenant_App.Web.Controllers
{
    public class BaseController : Controller
    {
        public string GetControllerAndActionName(Controller controller)
        {
            string actionName = ControllerContext.RouteData.Values["action"].ToString();
            string controllerName = ControllerContext.RouteData.Values["controller"].ToString();

            return "Controller: " + controllerName + (!string.IsNullOrEmpty(actionName) ? " ; Action Name: " + actionName : string.Empty);
        }

        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User);
            }
        }

        protected string GetCurrentUserId()
        {
            return User.Identity.GetUserId<string>();
        }
        public string getAction()
        {
            return ControllerContext.ActionDescriptor.ActionName;
        }

        public string getController()
        {
            return ControllerContext.ActionDescriptor.ControllerName;
        }
    }
}