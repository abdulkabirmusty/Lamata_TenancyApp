using System;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Models.Domains.ErrorLog;
using Tenant_App.Models.Data;

namespace Tenant_App.Services.Handler.ErrorLogger
{
    public class ErrorLoggerService : IErrorLogger
    {
        private readonly AppDbContext _context;
        
        public ErrorLoggerService(AppDbContext context)
        {
            _context = context;
        }

        public void LogError(Exception ex, string controllerOrMethodName)
        {
            ErrorLog newRecord = new ErrorLog
            {
                CreatedDate = DateTime.Now,
                MethodController = controllerOrMethodName,
                ErrorDetails = ex.InnerException == null ? ("<strong>Error Message:</strong><br/>" + ex.Message + "<br/><strong>StackTrace:</strong><br/>" + ex.StackTrace)
                : "<strong>Error Message:</strong><br/>" + ex.Message + "<br/><strong>StackTrace:</strong><br/>" + ex.StackTrace +
                "<br/><br/><strong>Inner Exception Message:</strong><br/>" + ex.InnerException.Message + "<br/><strong>Inner Exception StackTrace:</strong><br/>" + ex.InnerException.StackTrace
            };

            _context.ErrorLogs.Add(newRecord);
            _context.SaveChanges();
        }
    }
}
