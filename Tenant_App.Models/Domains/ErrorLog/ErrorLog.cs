using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.ErrorLog
{
    public class ErrorLog :BaseObject
    {
        public string ErrorDetails { get; set; }
        public string MethodController { get; set; }

    }
}
