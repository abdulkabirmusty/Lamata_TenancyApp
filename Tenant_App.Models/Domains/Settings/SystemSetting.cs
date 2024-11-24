using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.Settings
{
   public class SystemSetting :BaseObject
    {
      
            public string LookUpCode { get; set; }
            public string ItemName { get; set; }
            public string ItemValue { get; set; }
        
    }
}
