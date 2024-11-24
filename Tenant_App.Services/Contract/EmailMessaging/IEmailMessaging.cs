using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.EmailMessaging;
using Tenant_App.Services.Handler.EmailMessaging;

namespace Tenant_App.Services.Contract.EmailMessaging
{
   public  interface  IEmailMessaging
    {
		Task<EmailTemplateViewModel> GetEmailTemplateByCode(string Code);

		Task<bool> PrepareEmailLog(string emailTemplateCode, string emailTo, string cc, string bcc, List<EmailTokenViewModel> emailTokens);

		Task<bool> SendEmail(EmailLogViewModel emailModel);
	}
}
