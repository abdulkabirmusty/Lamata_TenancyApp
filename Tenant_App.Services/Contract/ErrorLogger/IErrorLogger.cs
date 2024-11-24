using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Services.Contract.ErrorLogger
{
   public interface IErrorLogger
    {
        void LogError(Exception ex, string contollerOrMethodName);
    }
}
