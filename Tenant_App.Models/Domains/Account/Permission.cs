using System;
using System.ComponentModel.DataAnnotations;

namespace Tenant_App.Models.Domains.Account
{
    public class Permission : BaseObject
    {
        public string PermissionName { get; set; }

        public string PermissionCode { get; set; }
        public string Icon { get; set; }


        [Required(ErrorMessage = "Url is required")]
        public string Url { get; set; }
    }
}
