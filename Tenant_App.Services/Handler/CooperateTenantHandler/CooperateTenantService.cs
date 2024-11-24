using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.Account;
using Tenant_App.Models.DataObjects.AppSettings;
using Tenant_App.Models.DataObjects.ContestantDTOs;
using Tenant_App.Models.DataObjects.CooperateTenantDtos;
using Tenant_App.Models.DataObjects.DocumentDTOs;
using Tenant_App.Models.DataObjects.TenantDocumentDtos;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Models.Domains.CooperateTenantDomain;
using Tenant_App.Models.Domains.TenantDocument;
using Tenant_App.Services.Contract.CooperateTenantContract;
using Tenant_App.Services.Contract.EmailMessaging;
using Tenant_App.Services.Handler.EmailMessaging;
using Tenant_App.Utilities.Document;
using Tenant_App.Utilities.ExceptionUtility;
using Tenant_App.Utilities.PasswordUtility;
using Tenant_App.Utilities.DocumentHandler;
namespace Tenant_App.Services.Handler.CooperateTenantHandler
{
    public class CooperateTenantService : ICooperateTenant
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CooperateTenantService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailMessaging _emailManager;
        private readonly IConverter _converter;
		private readonly UserManager<User> _userManager;
        public const string FormC07DocumentYpe = "D4DB6076-E7AC-4905-96E4-8E0062D4EBF8";
        public const string BankReferenceType = "C4B55433-CBCE-40A3-BB89-F4897A4BD1AC";
        public const string DirectorProfileType = "AAE848C1-E700-481D-92D5-7097C72BF987";
        public CooperateTenantService(AppDbContext context, ILogger<CooperateTenantService> logger, IConfiguration configuration,
            IEmailMessaging emailManager, IConverter converter, UserManager<User> userManager)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _emailManager = emailManager;
            _converter = converter;
			_userManager = userManager;
		}

        public async Task<string> AcceptCooperateTenants(List<Guid> cooperateTenantId, string adminUserId)
        {
			string status = "";

			for (int i = 0; i < cooperateTenantId.Count; i++)
			{
				CooperateTenant cooperateTenant = _context.CooperateTenants.FirstOrDefault(x => x.Id == cooperateTenantId[i]);
				
				if (cooperateTenant != null)
				{
                    User user = _context.Users.Where(x => x.Email == cooperateTenant.CooperateEmail).FirstOrDefault();

                    if(user.Status == 0)
                    {
                        user.Status = 1;
                        user.IsApproved = false;

                        if (await _context.SaveChangesAsync() > 0)
                        {

                            var emailTokens = new List<EmailTokenViewModel>
                        {
                            new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = cooperateTenant.CompanyName},
                            new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
                        };

                            bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.DESK_OFFICER_APPROVER, cooperateTenant.CooperateEmail, _configuration["cc"], "", emailTokens);

                            status = ResponseErrorMessageUtility.RecordSaved;
                        }
                        else
                        {
                            status = ResponseErrorMessageUtility.RecordNotSaved;
                            break;
                        }
                    }
                    else if (user.Status == 1)
                    {
                        user.Status = 2;
                        user.IsApproved = true;
                        cooperateTenant.Status = true;

                        if (await _context.SaveChangesAsync() > 0)
                        {

                            var emailTokens = new List<EmailTokenViewModel>
                        {
                            new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = cooperateTenant.CompanyName},
                            new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
                        };

                            bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.TENANT_APPROVED, cooperateTenant.CooperateEmail, _configuration["cc"], "", emailTokens);

                            status = ResponseErrorMessageUtility.RecordSaved;
                        }
                        else
                        {
                            status = ResponseErrorMessageUtility.RecordNotSaved;
                            break;
                        }
                    }
					
                }
                else
                {
                    status = $"IndividualTenant with id {cooperateTenantId[i]} not found";
                    break;
                }




            }

			return status;
		}

        public async Task<string> RejectCooperateTenants(List<Guid> cooperateTenantId, string adminUserId)
        {
            string status = "";

            for (int i = 0; i < cooperateTenantId.Count; i++)
            {
                CooperateTenant cooperateTenant = _context.CooperateTenants.FirstOrDefault(x => x.Id == cooperateTenantId[i]);

                if (cooperateTenant != null)
                {
                    cooperateTenant.Status = false;

                    User user = _context.Users.Where(x => x.Email == cooperateTenant.CooperateEmail).FirstOrDefault();

                    if (user.Status == 0)
                    {
                        user.Status = 3;
                        user.IsApproved = false;

                        if (await _context.SaveChangesAsync() > 0)
                        {

                            var emailTokens = new List<EmailTokenViewModel>
                        {
                            new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = cooperateTenant.CompanyName},
                            new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
                        };

                            bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.DESK_OFFICER_REJECTION, cooperateTenant.CooperateEmail, _configuration["cc"], "", emailTokens);

                            status = ResponseErrorMessageUtility.RecordSaved;
                        }
                        else
                        {
                            status = ResponseErrorMessageUtility.RecordNotSaved;
                            break;
                        }
                    }
                    else if (user.Status == 1)
                    {
                        user.Status = 3;
                        user.IsApproved = false;

                        if (await _context.SaveChangesAsync() > 0)
                        {

                            var emailTokens = new List<EmailTokenViewModel>
                        {
                            new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = cooperateTenant.CompanyName},
                            new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
                        };

                            bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.TENANT_REJECTED, cooperateTenant.CooperateEmail, _configuration["cc"], "", emailTokens);

                            status = ResponseErrorMessageUtility.RecordSaved;
                        }
                        else
                        {
                            status = ResponseErrorMessageUtility.RecordNotSaved;
                            break;
                        }
                    }

                }
                else
                {
                    status = $"IndividualTenant with id {cooperateTenantId[i]} not found";
                    break;
                }




            }

            return status;
        }

        public async Task<string> CreateCooperateTenant(CooperateTenantRegDto cooperateTenantRegDTO)
        {
            string status = string.Empty;

            var existingContestant = _context.CooperateTenants.Any(x => x.CooperateEmail == cooperateTenantRegDTO.CooperateEmail);
            if (existingContestant == false)
            {
                CooperateTenant cooperateTenant = new CooperateTenant()
                {
                    CompanyName = cooperateTenantRegDTO.CompanyName,
                    CooperateEmail = cooperateTenantRegDTO.CooperateEmail,
                    Address = cooperateTenantRegDTO.Address,
                    MobilePhoneNo = cooperateTenantRegDTO.MobilePhoneNo,
                    PersonalContact = cooperateTenantRegDTO.PersonalContact,
                    CACRegNo = cooperateTenantRegDTO.CACRegNo,
                    TIN = cooperateTenantRegDTO.TIN,
                    IsConsent  = cooperateTenantRegDTO.IsConsent
                    
                };

                _context.CooperateTenants.Add(cooperateTenant);

                List<TenantDocumetDto> documents = new List<TenantDocumetDto>()
                {
                    GetDocumentDTO(cooperateTenantRegDTO.FormC07, DocumentUtils.FORM_C07),
                    GetDocumentDTO(cooperateTenantRegDTO.BankReference, DocumentUtils.BANK_REFERENCE),
                    GetDocumentDTO(cooperateTenantRegDTO.DirectorProfile, DocumentUtils.DIRECTOR_PROFILE)
                };
                UploadDocuments(documents, cooperateTenant.Id);

                

				
				// Create user with the role of 'Tenant'
				var user = new User();
				user.Id = Guid.NewGuid().ToString();
				user.UserName = cooperateTenantRegDTO.CooperateEmail;
				user.Email = cooperateTenantRegDTO.CooperateEmail;
				user.FirstName = cooperateTenantRegDTO.CompanyName;
				user.Status = 0;

				// Generate a random password (you may use your own method for password generation)
				string password = GenerateRandomPassword();

				// Hash the password before storing it in the database
				//user.PasswordHash = BcryptConfiguration.PasswordHashService.HashPassword(password);
				//user.PasswordHash = password;

				var result = await _userManager.CreateAsync(user, password);
                await _context.SaveChangesAsync();

                if (result.Succeeded)
				{
					// Assign the 'Tenant' role to the user
					await _userManager.AddToRoleAsync(user, "Tenant");

					var emailTokens = new List<EmailTokenViewModel>
					{
						new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = cooperateTenant.CompanyName},
						new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
						new EmailTokenViewModel { Token = EmailTokenConstants.USERNAME, TokenValue = cooperateTenant.CooperateEmail },
						new EmailTokenViewModel { Token = EmailTokenConstants.PASSWORD, TokenValue = password },
					};

					bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.TENANT_CREATION, cooperateTenant.CooperateEmail, _configuration["cc"], "", emailTokens);

					status = ResponseErrorMessageUtility.RecordSaved;

					return user.Id;
				}
				else
				{
					status = ResponseErrorMessageUtility.RecordNotSaved;
					return status;
				}

				
			}
			status = string.Format(ResponseErrorMessageUtility.RecordExistBefore, cooperateTenantRegDTO.CooperateEmail);
            return status;
        }

		private string GenerateRandomPassword(int length = 8)
		{
			const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@";

			var random = new Random();
			var passwordChars = new char[length];

			for (int i = 0; i < length; i++)
			{
				passwordChars[i] = validChars[random.Next(validChars.Length)];
			}

			return new string(passwordChars);
		}


		public TenantDocumetDto GetDocumentDTO(IFormFile document, string documentName)
        {
            var tenantDocumentType = _context.TenantDocumentTypes.FirstOrDefault(x => x.Name == documentName.ToLower().Trim());

            if (tenantDocumentType != null)
            {
                Guid tenantDocumentTypeId = tenantDocumentType.Id;
                // Use tenantDocumentTypeId
                return new TenantDocumetDto()
                {
                    TenantDocument = document,
                    TenantDocumentTypeId = tenantDocumentTypeId,
                };
            }
			return null;
          
        }

        public bool UploadDocuments(List<TenantDocumetDto> documents, Guid cooporateTenantId)
        {
            List<TenantDocumentType> documentType = _context.TenantDocumentTypes.ToList();
            foreach (var doc in documents)
            {
                if (doc.TenantDocument.Length > 0)
                {
                    string fileExtension = Path.GetExtension(doc.TenantDocument.FileName);
                    string fileName = $"{Path.GetFileName(doc.TenantDocument.FileName)}";
                    string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "TenantDoc");

                    if (!Directory.Exists(uploadsFolder)) { Directory.CreateDirectory(uploadsFolder); }

                    string filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    { doc.TenantDocument.CopyTo(stream); }

                    TenantDocument document = new TenantDocument
                    {
                        FileName = doc.TenantDocument.FileName,
                        DocumentTypeId = doc.TenantDocumentTypeId,
                        ComporateTenantId = cooporateTenantId,
                        DocumentPath = $"TenantDoc/{fileName}"
                    };

                    _context.TenantDocuments.Add(document);
                }
            }

            return true;
        }

        public List<CooperateTenantDto> GetAcceptedCooperateTenant()
        {
			return _context.CooperateTenants.Where(x => x.Status == true).Select(x => new CooperateTenantDto()
			{
				Id = x.Id,
				CompanyName = x.CompanyName,
				CooperateEmail = x.CooperateEmail,
				MobilePhoneNo = x.MobilePhoneNo,
				Status = x.Status
			}).ToList();
		}

        public List<CooperateTenantDto> GetAllCooperateTenant()
        {
			return _context.CooperateTenants.Select(x => new CooperateTenantDto()
			{
				Id = x.Id,
				CompanyName = x.CompanyName,
				CooperateEmail = x.CooperateEmail,
				MobilePhoneNo = x.MobilePhoneNo,
				Status = x.Status
			}).ToList();
		}

        public CooperateTenant GetById(Guid id)
        {
			return _context.CooperateTenants.FirstOrDefault(x => x.Id == id);
		}

        public CooperateTenantDto ViewCoperateTenant(Guid id)
        {
			CooperateTenant cooperateTenant = _context.CooperateTenants.FirstOrDefault(x => x.Id == id);

            var formC07Path = _context.TenantDocuments.FirstOrDefault(x => x.ComporateTenantId == id && x.DocumentTypeId == _context.TenantDocumentTypes.Where(x => x.Name == DocumentUtils.FORM_C07).Select(x => x.Id).FirstOrDefault());
			var bankReferencePath = _context.TenantDocuments.FirstOrDefault(x => x.ComporateTenantId == id && x.DocumentTypeId == _context.TenantDocumentTypes.Where(x => x.Name == DocumentUtils.BANK_REFERENCE).Select(x => x.Id).FirstOrDefault());
			var directorProfilePath = _context.TenantDocuments.FirstOrDefault(x => x.ComporateTenantId == id && x.DocumentTypeId == _context.TenantDocumentTypes.Where(x => x.Name == DocumentUtils.DIRECTOR_PROFILE).Select(x => x.Id).FirstOrDefault());

			return new CooperateTenantDto()
			{
				Id = cooperateTenant.Id,
				CompanyName = cooperateTenant.CompanyName,
				CooperateEmail = cooperateTenant.CooperateEmail,
				Status = cooperateTenant.Status,
				Address = cooperateTenant.Address,
				MobilePhoneNo = cooperateTenant.MobilePhoneNo,
				PersonalContact = cooperateTenant.PersonalContact,
				FormC07 = formC07Path.ToString(),
				BankReference = bankReferencePath.ToString(),
				DirectorProfile = directorProfilePath.ToString(),
                DocumentPath= formC07Path.DocumentPath,
			    DocumentPathRef = bankReferencePath.DocumentPath,
				DocumentPathRefDir = directorProfilePath.DocumentPath

            };
		}
    }
}
