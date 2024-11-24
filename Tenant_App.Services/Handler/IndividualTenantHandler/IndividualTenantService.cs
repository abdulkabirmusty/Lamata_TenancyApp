using DinkToPdf.Contracts;
using Tenant_App.Models.Data;
using Tenant_App.Services.Contract.EmailMessaging;
using Tenant_App.Utilities.ExceptionUtility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.Account;
using Tenant_App.Models.DataObjects.IndividualTenantDtos;
using Tenant_App.Models.Domains.IndividualTenantDomain;
using Tenant_App.Services.Contract.IndividualTenantContract;
using Tenant_App.Services.Handler.EmailMessaging;
using Tenant_App.Utilities.PasswordUtility;
using Tenant_App.Models.Domains.Account;
using Microsoft.AspNetCore.Identity;
using Tenant_App.Models.Domains.CooperateTenantDomain;

namespace Tenant_App.Services.Handler.IndividualTenantHandler
{
	public class IndividualTenantService : IIndividualTenant
	{
		private readonly AppDbContext _context;
		private readonly ILogger<IndividualTenantService> _logger;
		private readonly IConfiguration _configuration;
		private readonly IEmailMessaging _emailManager;
		private readonly IConverter _converter;
		private readonly UserManager<User> _userManager;

		public IndividualTenantService(AppDbContext context, ILogger<IndividualTenantService> logger, IConfiguration configuration,
			IEmailMessaging emailManager, IConverter converter, UserManager<User> userManager)
		{
			_context = context;
			_logger = logger;
			_configuration = configuration;
			_emailManager = emailManager;
			_converter = converter;
			_userManager = userManager;
		}

		public async Task<string> AcceptIndividual(List<Guid> individualTenantIds, string adminUserId)
		{
            string status = "";

            for (int i = 0; i < individualTenantIds.Count; i++)
            {
                IndividualTenant individualTenant = _context.IndividualTenants.FirstOrDefault(x => x.Id == individualTenantIds[i]);

                if (individualTenant != null)
                {
                    User user = _context.Users.Where(x => x.Email == individualTenant.Email).FirstOrDefault();
					if(user.Status == 0)
					{
						user.Status = 1;
						user.IsApproved = false;

						if (await _context.SaveChangesAsync() > 0)
						{
							var emailTokens = new List<EmailTokenViewModel>
							{
								new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = $"{individualTenant.FirstName} {individualTenant.LastName}" },
								new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
							};

							bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.DESK_OFFICER_APPROVER, individualTenant.Email, _configuration["cc"], "", emailTokens);

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
                        individualTenant.Status = true;

                        if (await _context.SaveChangesAsync() > 0)
						{
							var emailTokens = new List<EmailTokenViewModel>
							{
								new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = $"{individualTenant.FirstName} {individualTenant.LastName}" },
								new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
							};

							bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.TENANT_APPROVED, individualTenant.Email, _configuration["cc"], "", emailTokens);

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
                    status = $"IndividualTenant with id {individualTenantIds[i]} not found";
                    break;
                }
            }

            return status;
        }

		public async Task<string> RejectIndividual(List<Guid> individualTenantIds, string adminUserId)
		{
			string status = "";

			for (int i = 0; i < individualTenantIds.Count; i++)
			{
				IndividualTenant individualTenant = _context.IndividualTenants.FirstOrDefault(x => x.Id == individualTenantIds[i]);

				if (individualTenant != null)
				{
					individualTenant.Status = false;

					User user = _context.Users.Where(x => x.Email == individualTenant.Email).FirstOrDefault();
					if (user.Status == 0)
					{
						user.Status = 3;
						user.IsApproved = false;

						if (await _context.SaveChangesAsync() > 0)
						{
							var emailTokens = new List<EmailTokenViewModel>
							{
								new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = $"{individualTenant.FirstName} {individualTenant.LastName}" },
								new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
							};

							bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.DESK_OFFICER_REJECTION, individualTenant.Email, _configuration["cc"], "", emailTokens);

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
								new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = $"{individualTenant.FirstName} {individualTenant.LastName}" },
								new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
							};

							bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.TENANT_REJECTED, individualTenant.Email, _configuration["cc"], "", emailTokens);

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
					status = $"IndividualTenant with id {individualTenantIds[i]} not found";
					break;
				}
			}

			return status;
		}

		public async Task<string> CreateIndividualTenant(IndividualTenantRegDto individualTenantDto)
		{
			string status = string.Empty;

			// Check if an individual tenant with the given email already exists
			var existingTenant = _context.IndividualTenants.Any(x => x.Email == individualTenantDto.Email);

			if (!existingTenant)
			{
				// Create IndividualTenant object
				var individualTenant = new IndividualTenant
				{
					FirstName = individualTenantDto.FirstName,
					LastName = individualTenantDto.LastName,
					CurrentAddress = individualTenantDto.CurrentAddress,
					HomePhoneNo = individualTenantDto.HomePhoneNo,
					WorkPhoneNo = individualTenantDto.WorkPhoneNo,
					Email = individualTenantDto.Email,
					DOB = individualTenantDto.DOB,
					Sex = individualTenantDto.Sex,
					RentDuration = individualTenantDto.RentDuration,
					Nationality = individualTenantDto.Nationality,
					StateOfOrigin = individualTenantDto.StateOfOrigin,
					IdentityType = individualTenantDto.IdentityType,
					IdentityAttach = UploadImageFile(individualTenantDto.Identityfile),
					SignaturePath = UploadImageFile(individualTenantDto.Signature),
					PassportPath = UploadImageFile(individualTenantDto.Passport),
					BankAccountNo = individualTenantDto.BankAccountNo,
					BankName = individualTenantDto.BankName,
					AccountName = individualTenantDto.AccountName,
					TypeOfBusiness = individualTenantDto.TypeOfBusiness,
					IsConsent = individualTenantDto.IsConsent,
				};

				// Create NextOfKin object
				var nextOfKin = new NextOfKin
				{
					FullName = individualTenantDto.nextOfKinFullName,
					Relationship = individualTenantDto.Relationship,
					Address = individualTenantDto.NextOfKinAddress,
					Email = individualTenantDto.NextOfKinEmail,
					MobilePhoneNo = individualTenantDto.NextOfKinMobilePhoneNo,
					WorkPhoneNo = individualTenantDto.NextOfKinWorkPhoneNo,
				};

				// Create RentalHistory object
				var rentalHistory = new RentalHistory
				{
					PreviousAddress = individualTenantDto.PreviousAddress,
					LengthOfTime = individualTenantDto.LengthOfTime,
				};

				// Create Referee objects
				var referees = individualTenantDto.Refereees.Select(r => new Referee
				{
					FullName = r.FullName,
					Relationship = r.Relationship,
					MobileNo = r.MobileNo,
					SignaturePath = UploadRefImageFile(r.Signature),
					IndividualTenantId = individualTenant.Id,
				}).ToList();

				// Add objects to the IndividualTenant
				individualTenant.NextOfKin = nextOfKin;
				individualTenant.RentalHistory = rentalHistory;

                foreach (var referee in referees)
                {
                    individualTenant.Referees.Add(referee);
                }

                // Save to the database
                _context.IndividualTenants.Add(individualTenant);
				

				// Create user with the role of 'Tenant'
				var user = new User();
				user.Id = Guid.NewGuid().ToString();
				user.UserName = individualTenantDto.Email;
				user.Email = individualTenantDto.Email;
				user.FirstName = individualTenantDto.FirstName;
				user.Status = 0;

				// Generate a random password 
				string password = GenerateRandomPassword();

				var result = await _userManager.CreateAsync(user, password);

				if (result.Succeeded)
				{
					// Assign the 'Tenant' role to the user
					await _userManager.AddToRoleAsync(user, "Tenant");

					var emailTokens = new List<EmailTokenViewModel>
					{
						new EmailTokenViewModel { Token = EmailTokenConstants.FULLNAME, TokenValue = $"{individualTenant.FirstName} {individualTenant.LastName}" },
						new EmailTokenViewModel { Token = EmailTokenConstants.PORTALNAME, TokenValue = _configuration["PortalName"] },
						new EmailTokenViewModel { Token = EmailTokenConstants.USERNAME, TokenValue = individualTenant.Email },
						new EmailTokenViewModel { Token = EmailTokenConstants.PASSWORD, TokenValue = password },
					};

					bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.TENANT_CREATION, individualTenant.Email, _configuration["cc"], "", emailTokens);

					status = ResponseErrorMessageUtility.RecordSaved;
					return status;
				}
				else
				{
					// Handle user creation failure, e.g., log errors, return an error message, etc.
					status = ResponseErrorMessageUtility.RecordNotSaved;
					return status;
				}
			}
			await _context.SaveChangesAsync();

			status = string.Format(ResponseErrorMessageUtility.RecordExistBefore, individualTenantDto.Email);
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

        private string DecodePassword(string encodedPassword)
        {
            // Convert the Base64 string to a byte array
            byte[] bytes = Convert.FromBase64String(encodedPassword);

            // Convert the byte array back to a string
            string decodedPassword = Encoding.UTF8.GetString(bytes);

            return decodedPassword;
        }

        public string UploadImageFile(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string fileName = $"{Path.GetFileName(file.FileName)}";
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string filePath = Path.Combine(uploadsFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"uploads/{fileName}";
        }

		public string UploadRefImageFile(IFormFile file)
		{
			if (file == null || file.Length == 0)
			{
				// Handle the case when the file is not provided
				return null;
			}

			string fileExtension = Path.GetExtension(file.FileName);
			string fileName = $"{Path.GetFileName(file.FileName)}";
			string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

			if (!Directory.Exists(uploadsFolder))
			{
				Directory.CreateDirectory(uploadsFolder);
			}

			string filePath = Path.Combine(uploadsFolder, fileName);
			using (var stream = new FileStream(filePath, FileMode.Create))
			{
				file.CopyTo(stream);
			}

			return $"uploads/{fileName}";
		}


		public byte[] DownloadTenantInfo(string IndividualTenantId)
		{
			throw new NotImplementedException();
		}

		public List<IndividualTenantDto> GetAllIndividualTenant()
		{
			return _context.IndividualTenants.Select(x => new IndividualTenantDto()
			{
				Id = x.Id,
				FirstName = x.FirstName,
				LastName = x.LastName,
				HomePhoneNo = x.HomePhoneNo,
				Email = x.Email,
				RentDuration = x.RentDuration,
				Status = x.Status
			}).ToList();
		}

		public List<IndividualTenantDto> GetApprovedTenant()
		{
			return _context.IndividualTenants.Where(x => x.Status == true).Select(x => new IndividualTenantDto()
			{
				Id = x.Id,
				FirstName = x.FirstName,
				LastName = x.LastName,
				HomePhoneNo = x.HomePhoneNo,
				Email = x.Email,
				RentDuration = x.RentDuration,
				Status = x.Status
			}).ToList();
		}

		public IndividualTenant GetById(Guid id)
		{
			return _context.IndividualTenants.FirstOrDefault(x => x.Id == id);
		}

		public IndividualTenantDto ViewIndividualTenant(Guid id)
		{
			IndividualTenant individualTenant = _context.IndividualTenants
							.Include(t => t.NextOfKin)
							.Include(t => t.RentalHistory)
							.Include(t => t.Referees)
							.FirstOrDefault(t => t.Id == id);

			

			// Map the IndividualTenant entity to IndividualTenantDto
			IndividualTenantDto tenantDto = new IndividualTenantDto
			{
				Id = individualTenant.Id,
				FirstName = individualTenant.FirstName,
				LastName = individualTenant.LastName,
				CurrentAddress = individualTenant.CurrentAddress,
				HomePhoneNo = individualTenant.HomePhoneNo,
				WorkPhoneNo = individualTenant.WorkPhoneNo,
				Status = individualTenant.Status,
				Email = individualTenant.Email,
				DOB = individualTenant.DOB,
				Sex = individualTenant.Sex,
				RentDuration = individualTenant.RentDuration,
				Nationality = individualTenant.Nationality,
				StateOfOrigin = individualTenant.StateOfOrigin,
				IdentityType = individualTenant.IdentityType,
				IdentityAttach = individualTenant.IdentityAttach,
				SignaturePath = individualTenant.SignaturePath,
				PassportPath = individualTenant.PassportPath,
				//nextOfKinFullName = individualTenant.NextOfKin.,
				//Relationship = individualTenant.NextOfKin.Relationship,
				//NextOfKinAddress = individualTenant.NextOfKin.Address,
				//NextOfKinEmail = individualTenant.NextOfKin.Email,
				//NextOfKinMobilePhoneNo = individualTenant.NextOfKin.MobilePhoneNo,
				//NextOfKinWorkPhoneNo = individualTenant.NextOfKin.WorkPhoneNo,
				//PreviousAddress = individualTenant.RentalHistory.PreviousAddress,
				//LengthOfTime = individualTenant.RentalHistory.LengthOfTime,
				//Referees = individualTenant.Referees.Select(r => new RefereeDto
				//{
				//	FullName = r.FullName,
				//	Relationship = r.Relationship,
				//	MobileNo = r.MobileNo,
				//	SignaturePath = r.SignaturePath
				//}).ToList()
			};

			return tenantDto;
		}
	}
}
