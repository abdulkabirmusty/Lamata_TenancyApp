using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Tenant_App.Models.DataObjects.EmailMessaging;
using Tenant_App.Models.Domains.EmailTemplate;
using Tenant_App.Services.Contract.EmailMessaging;
using Tenant_App.Utilities.AuthenticationUtility.AuthUser;
using Tenant_App.Utilities.ExceptionUtility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;
using Tenant_App.Models.Data;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace Tenant_App.Services.Handler.EmailMessaging
{
    public class EmailMessagingServices : IEmailMessaging
    {
		private readonly AppDbContext _context;
		private readonly ILogger<EmailMessagingServices> _logger;
		private readonly MailSettings _mailSettings;


		public EmailMessagingServices(AppDbContext context, ILogger<EmailMessagingServices> logger, IOptions<MailSettings> mailMettings)
		{
			_context = context;
			_logger = logger;
			_mailSettings = mailMettings.Value;
		}

		public async Task<EmailTemplateViewModel> GetEmailTemplateByCode(string Code)
		{
			EmailTemplateViewModel model = new EmailTemplateViewModel();

			try
			{
				return await _context.EmailTemplates
				.Where(x => x.Code.ToLower() == Code.ToLower())
				.Select(model => new EmailTemplateViewModel
				{
					Subject = model.Subject,
					MailBody = model.MailBody,
					Code = model.Code,
					Description = model.Description,
				})
				.FirstOrDefaultAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return model;
			}
		}

		public async Task<bool> PrepareEmailLog(string emailTemplateCode, string emailTo, string cc, string bcc, List<EmailTokenViewModel> emailTokens)
		{
			EmailLogViewModel emailLogViewModel = new EmailLogViewModel();
			try
			{
				EmailTemplate emailTemplate = _context.EmailTemplates.FirstOrDefault(x => x.Code == emailTemplateCode);

				StringBuilder sbEmailBody = new StringBuilder();
				sbEmailBody.Append(emailTemplate.MailBody);

				foreach (var token in emailTokens)
				{
					sbEmailBody = sbEmailBody.Replace(token.Token, token.TokenValue);
				}

				string newMessage = sbEmailBody.ToString();

				EmailLogViewModel newEmailLog = new EmailLogViewModel
				{
					Receiver = emailTo,
					CC = string.IsNullOrEmpty(cc) ? null : cc,
					BCC = string.IsNullOrEmpty(bcc) ? null : bcc,
					MessageBody = sbEmailBody.ToString(),
					Subject = emailTemplate.Subject,
				};

				if (newEmailLog != null)
				{
					return await SendEmail(newEmailLog);
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex.Message);
				return false;
			}
		}


		public async Task<bool> SendEmail(EmailLogViewModel emailModel)
		{
			try
			{
				MimeMessage email = new MimeMessage();

				email.Sender = MailboxAddress.Parse(_mailSettings.Email);
				email.To.Add(MailboxAddress.Parse(emailModel.Receiver));
				email.Subject = emailModel.Subject;

				BodyBuilder builder = new BodyBuilder
				{ HtmlBody = emailModel.MessageBody };
				email.Body = builder.ToMessageBody();

				using SmtpClient smtpClient = new SmtpClient();
				smtpClient.Connect(_mailSettings.Host, _mailSettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
				smtpClient.Authenticate(_mailSettings.UserName, _mailSettings.Password);
				await smtpClient.SendAsync(email);
				smtpClient.Disconnect(true);

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}