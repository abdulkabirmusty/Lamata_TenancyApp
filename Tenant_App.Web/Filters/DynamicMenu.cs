using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.Icon;
using Tenant_App.Models.Domains.Account;

namespace Tenant_App.Web.Filters
{
    public class DynamicMenu
    {
        private readonly IConfiguration _configuration;
        public DynamicMenu(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static List<SidebarMenuViewModel> GenerateUrl(List<Permission> menus)
        {
            List<SidebarMenuViewModel> sidebarMenus = null;
            string alias = "";

            sidebarMenus = new List<SidebarMenuViewModel>();

            foreach (var menu in menus)
            {
                sidebarMenus.Add(new SidebarMenuViewModel
                {
                    Icon = menu.Icon,
                    MenuText = menu.PermissionName,
                    Alias = alias,
                    Url = menu.Url,
                    PID = menu.Id.ToString(),   // PermissionId
                }); ;
            }

            return sidebarMenus;
        }
    }
}
