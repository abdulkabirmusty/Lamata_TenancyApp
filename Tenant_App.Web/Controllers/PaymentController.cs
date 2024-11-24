using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NToastNotify;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Models.Domains.Payment;
using Tenant_App.Services.Contract.EmailMessaging;
using Tenant_App.Services.Contract.ErrorLogger;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text;
using Tenant_App.Models.DataObjects.EmailMessaging;
using Tenant_App.Services.Handler.EmailMessaging;
using Microsoft.AspNetCore.Authorization;
using Tenant_App.Models.DataObjects.PaymentDtos;
using Tenant_App.Services.Contract.PaymentContract;
using Tenant_App.Models.Domains.CooperateTenantDomain;
using Tenant_App.Utilities.ExceptionUtility;

namespace Tenant_App.Web.Controllers
{
	[AllowAnonymous]
	public class PaymentController : BaseController
	{
		private readonly IConfiguration _configuration;
		private readonly IToastNotification _toastNotification;
		private readonly RemitaSettings _remitaSettings;
		HttpClient _client;
		private readonly UserManager<User> _userManager;
		private readonly IErrorLogger _errorLogger;
        private readonly IPaymentService _paymentService;
        private readonly IEmailMessaging _emailMessaging;

		public PaymentController(IConfiguration configuration,
			IToastNotification toastNotification, IOptions<RemitaSettings> remitaSettings,
			UserManager<User> userManager, IErrorLogger errorLogger, IPaymentService paymentService,
			IEmailMessaging emailMessaging)
		{
			_configuration = configuration;
			_client = new HttpClient();
			_toastNotification = toastNotification;
			_remitaSettings = remitaSettings.Value;
			_userManager = userManager;
			_errorLogger = errorLogger;
            _paymentService = paymentService;
            _emailMessaging = emailMessaging;
		}
		[AllowAnonymous]
		public async Task<IActionResult> InitiateAndConfirmPayment(decimal amount, string userId)
		{
			try
			{
				decimal technologyFee = TechnologyFee(amount);

				User user = await _userManager.FindByIdAsync(userId);
				RemitaSplitPaymentRequest remitaSplitPaymentRequest = await GetRemitaSplitPaymentRequest(amount, technologyFee, user);

				return await SendRemitaPaymentRequest(remitaSplitPaymentRequest, technologyFee, user);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				return RedirectToAction("SystemError");
			}
		}

		public IActionResult SystemError()
		{
			return View("Error");
		}

		private async Task<RemitaSplitPaymentRequest> GetRemitaSplitPaymentRequest(decimal amount, decimal technologyFee, User user)
		{
			decimal totalAmount = amount + technologyFee;

			List<RemitaSplitLineItems> remitaSplitLineItems = new List<RemitaSplitLineItems>();
			string orderId = Guid.NewGuid().ToString();

			string hash = GenerateApiHash(_remitaSettings.MerchantId, _remitaSettings.ServiceTypeId,
											  orderId, totalAmount.ToString(), _remitaSettings.ApiKey);

			RemitaSplitLineItems remitaSplitLineItem1 = new RemitaSplitLineItems()
			{
				lineItemsId = "itemid1",
				beneficiaryName = _configuration["NABTEBPaymentDetails:Name"],
				beneficiaryAccount = _configuration["NABTEBPaymentDetails:Account"],
				bankCode = "058",
				beneficiaryAmount = amount.ToString(),
				deductFeeFrom = "1"
			};
			remitaSplitLineItems.Add(remitaSplitLineItem1);

			RemitaSplitLineItems remitaSplitLineItem2 = new RemitaSplitLineItems()
			{
				lineItemsId = "itemid2",
				beneficiaryName = _configuration["VatebraPaymentDetails:Name"],
				beneficiaryAccount = _configuration["VatebraPaymentDetails:Account"],
				bankCode = "058",
				beneficiaryAmount = technologyFee.ToString(),
				deductFeeFrom = "0"
			};
			remitaSplitLineItems.Add(remitaSplitLineItem2);

			RemitaSplitPaymentRequest remitaSplitPaymentRequest = new RemitaSplitPaymentRequest
			{
				serviceTypeId = _remitaSettings.ServiceTypeId,
				merchantId = _remitaSettings.MerchantId,
				apiKey = _remitaSettings.ApiKey,
				amount = totalAmount.ToString(),
				orderId = orderId,
				payerName = user.UserName,
				payerEmail = user.Email,
				payerPhone = "07063524896",
				description = "Tenant Registration Fee",
				lineItems = remitaSplitLineItems,
				hash = hash
			};

			return remitaSplitPaymentRequest;
		}

		private async Task<IActionResult> SendRemitaPaymentRequest(RemitaSplitPaymentRequest remitaSplitPaymentRequest, decimal technologyFee, User user)
		{
			try
			{
				_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("remitaConsumerKey", _remitaSettings.MerchantId);
				_client.DefaultRequestHeaders.Add("remitaConsumerToken", remitaSplitPaymentRequest.hash);

				HttpResponseMessage response = await _client.PostAsJsonAsync(_remitaSettings.RrrTransactionURL, remitaSplitPaymentRequest);
				if (response.IsSuccessStatusCode)
				{
					string remitaResponseString = await response.Content.ReadAsStringAsync();
					RemitaSplitPaymentResponse remitaSplitPaymentResponse = await response.Content.ReadAsAsync<RemitaSplitPaymentResponse>();

					if (remitaSplitPaymentResponse.statuscode == "025")
					{
						RemitaSplitPaymentSummary remitaSplitPaymentSummary = new RemitaSplitPaymentSummary
						{
							Amount = remitaSplitPaymentRequest.amount,
							FirstName = user.FirstName,
							LastName = user.FirstName,
							Email = user.Email,
							OrderId = remitaSplitPaymentRequest.orderId,
							Narration = remitaSplitPaymentRequest.description,
							RRR = remitaSplitPaymentResponse.RRR,
							PublicKey = _remitaSettings.PublicKey,
							UserId = user.Id,
							TechnologyFee = technologyFee.ToString()
						};

						return PartialView("InitiatePayment", remitaSplitPaymentSummary);
					}
				}

				return RedirectToAction("PaymentFailure");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error in SendRemitaPaymentRequest: {ex.Message}");
				throw;
			}
		}

		private string GenerateApiHash(string merchantId, string serviceTypeId, string orderId, string totalAmount, string apiKey)
		{
			var concatenatedString = $"{merchantId}{serviceTypeId}{orderId}{totalAmount}{apiKey}";

			using (var sha512 = SHA512.Create())
			{
				var hashedBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(concatenatedString));
				return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
			}
		}

		public decimal TechnologyFee(decimal amount)
		{
			string technologyFeeString = _configuration["VatebraPaymentDetails:TechnologyFee"];
			decimal technologyFee = decimal.Parse(technologyFeeString);

			return decimal.Round((amount * technologyFee), 2);
		}


		public async Task<IActionResult> ConfirmPayment(string userId, decimal amount, string rrr, bool isSuccessful)
		{
			try
			{
				
				await _paymentService.CreatePayment(userId, amount, rrr, isSuccessful);

				if (isSuccessful)
				{
					// SEND EMAIL 
					EmailTemplateViewModel emailTemplate = await _emailMessaging.GetEmailTemplateByCode(EmailTemplateCode.REMITA_SUCCESS);
					User user = await _userManager.FindByIdAsync(userId);

					List<EmailTokenViewModel> emailTokens = new List<EmailTokenViewModel>
					{
							new EmailTokenViewModel {  Token = EmailTokenConstants.FULLNAME,  TokenValue =  $"{user.FirstName} {user.LastName}"},
							new EmailTokenViewModel {  Token = EmailTokenConstants.RRR,  TokenValue =  rrr },
							new EmailTokenViewModel {  Token = EmailTokenConstants.AMOUNT,  TokenValue = amount.ToString() },
                    };

                    bool mailresponse = await _emailMessaging.PrepareEmailLog(EmailTemplateCode.REMITA_SUCCESS, user.Email, _configuration["cc"], "", emailTokens);

                    _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.PaymentSuccesful, null);
                    return RedirectToAction("Index", "Properties");

                }
				else
				{
                    _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.PaymentFailure, null);
                    return RedirectToAction("Index", "Properties");
                }
			}
			catch (Exception ex)
			{
				_errorLogger.LogError(ex, GetControllerAndActionName(this));
                return RedirectToAction("PaymentFailure");
            }
		}
	}
}
