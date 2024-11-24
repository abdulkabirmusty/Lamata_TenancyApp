using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Tenant_App.Models.Domains;

namespace Tenant_App.Models.DataObjects.Settings
{
    public class SystemSettingViewModel : BaseObjectDataIntegrity
    { 
        [Required]
        public string LookUpCode { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string ItemValue { get; set; }
    }
}
