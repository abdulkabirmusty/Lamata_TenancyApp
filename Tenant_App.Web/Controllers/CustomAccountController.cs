using Hangfire;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.Account;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Models.DTOs;
using Tenant_App.Services.Contract.Account;
using Tenant_App.Services.Contract.EmailMessaging;
using Tenant_App.Services.Contract.ErrorLogger;
using Tenant_App.Utilities.ExceptionUtility;
using Tenant_App.Utilities.Extensions;
using Tenant_App.Web.Models;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.IndividualTenantDtos;
using Tenant_App.Services.Contract.CooperateTenantContract;
using Tenant_App.Services.Contract.IndividualTenantContract;
using Tenant_App.Services.Contract.TenantDocumentContract;
using Tenant_App.Models.Constants;

namespace Tenant_App.Web.Controllers
{
    public class CustomAccountController : BaseController
    {
        private readonly AppDbContext _context;
        protected readonly UserManager<User> _userManager;
        protected readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        protected readonly RoleManager<IdentityRole> _roleManager;
        private readonly IToastNotification _toastNotification;
        private readonly IErrorLogger _errorLogger;
        private readonly IEmailMessaging _emailManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;
        readonly IServiceProvider _serviceProvider;
        private readonly IRole _roleService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IIndividualTenant _individualTenant;
        private readonly ICooperateTenant _cooperateTenant;
        private readonly ITenantDocument _documentService;

        public CustomAccountController(UserManager<User> userManager, SignInManager<User> signInManager, 
            RoleManager<IdentityRole> roleManager, IConfiguration configuration, IToastNotification toastNotification,
            AppDbContext context, IErrorLogger errorLogger, IEmailMessaging emailManager, IHttpContextAccessor httpContextAccessor,
            IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager, IServiceProvider serviceProvider,
            IIndividualTenant individualTenant, ICooperateTenant cooperateTenant, ITenantDocument documentService,
           IRole roleService, IAuthenticationService authenticationService, IAuthorizationService authorizationService)
        {

            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _toastNotification = toastNotification;
            _errorLogger = errorLogger;
            _emailManager = emailManager;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _serviceProvider = serviceProvider;
            _roleService = roleService;
            _authenticationService = authenticationService;
            _authorizationService = authorizationService;
            _individualTenant = individualTenant;
            _cooperateTenant = cooperateTenant;
            _documentService = documentService;
        }

        
        
        [AllowAnonymous]
        [HttpGet("CustomAccount/TenantRegister")]
        public IActionResult TenantRegister()
        {
            try
            {
                var model = new IndividualTenantRegDto();
                // Ensure Referees list has at least one element
                model.Refereees.Add(new RefereeeDto());
				ViewBag.BankNames = _context.Banks.Select(d => d.Name).ToList();
				return View(model);
            }
            catch (Exception ex)
            {
                return SystemError(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("CustomAccount/TenantRegister")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TenantRegister(IndividualTenantRegDto individualTenantDto)
        {
            try
            {
                if (string.IsNullOrEmpty(individualTenantDto.Email))
                {
                    string msg = ModelState.FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors.FirstOrDefault().ErrorMessage;
                    string displayMsg = msg.Replace("'", "");

                    _toastNotification.AddWarningToastMessage(displayMsg, null);

                    return View(individualTenantDto);
                }

                var response = await _individualTenant.CreateIndividualTenant(individualTenantDto);
                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.TenantSuccesful, null);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(individualTenantDto);
            }
        }

        [AllowAnonymous]
        [HttpGet("CustomAccount/CooperateTenantRegister")]
        public IActionResult CooperateTenantRegister()
        {
            try
            {
                var model = new CooperateTenantRegDto();
                ViewBag.TenantDocumentTypes = _documentService.GetAllDocumentTypes();
                return View(model);
            }
            catch (Exception ex)
            {
                return SystemError(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("CustomAccount/CooperateTenantRegister")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CooperateTenantRegister(CooperateTenantRegDto cooperateTenantDto)
        {
            try
            {
                if (string.IsNullOrEmpty(cooperateTenantDto.CooperateEmail))
                {
                    string msg = ModelState.FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors.FirstOrDefault().ErrorMessage;
                    string displayMsg = msg.Replace("'", "");

                    _toastNotification.AddWarningToastMessage(displayMsg, null);

                    ViewBag.TenantDocumentTypes = _documentService.GetAllDocumentTypes();
                    return View(cooperateTenantDto);
                }

                var response = await _cooperateTenant.CreateCooperateTenant(cooperateTenantDto);

                if(response == ResponseErrorMessageUtility.RecordNotSaved)
                {
					_toastNotification.AddWarningToastMessage(ResponseErrorMessageUtility.TenantUnsuccesful, null);
					ViewBag.TenantDocumentTypes = _documentService.GetAllDocumentTypes();
					return View(cooperateTenantDto);
				}
                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.TenantSuccesful, null);
                //return RedirectToAction("Index", "Home");

                //var payment = new RegPaymentDto()
                //{
                //    FullName = cooperateTenantDto.CompanyName,
                //    Email = cooperateTenantDto.CooperateEmail,
                //    Amount = 2000,
                //    UserId = response

                //};



                //return PartialView("viewAmount", payment);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(cooperateTenantDto);
            }
        }


		[AllowAnonymous]
        [HttpGet("CustomAccount/Login")]
        public IActionResult Login(string ? ReturnUrl)
        {
           // ReturnUrl = "";
            LoginDTO model = new LoginDTO();
            HttpContext.Session.Clear();

             if (ReturnUrl == "/")
            {
                return View(model);
            }

            if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
            {
                return Redirect(ReturnUrl); // Redirect to the original requested URL
            }
            

            return View(model);

        }

        [HttpPost("CustomAccount/Login")]
        [AllowAnonymous]
       // [Obsolete]
        public async Task<IActionResult> Login(LoginDTO loginDTO, string ReturnUrl = null)
        {
            HttpContext.Session.Clear();

            loginDTO.password.RemoveWhiteSpace();
            loginDTO.email.RemoveWhiteSpace();

            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView("Login", loginDTO);
                }

                var user = _userManager.Users.FirstOrDefault(x => x.UserName == loginDTO.email || x.Email ==loginDTO.email);
                if (user == null)
                {
                    _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.InvalidAccount, null);
                    return PartialView("Login", loginDTO);
                }

                var isApproved = user.IsApproved;

                if (isApproved == false && user.Email != "Admin@gmail.com" && user.Email != "deskofficer@lamata.com")
                {
                    _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.NotApprove, null);
                    return PartialView("Login", loginDTO);
                }

                User signedUser = await _userManager.FindByNameAsync(user.UserName);

                bool checkPassword = await _userManager.CheckPasswordAsync(signedUser, loginDTO.password);
                if (checkPassword == false)
                {
                    _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.InvalidAccount, null);
                    return PartialView("Login", loginDTO);
                }

                var signInResult = await _signInManager.PasswordSignInAsync(user, loginDTO.password, false, false);
                if (signInResult.Succeeded)
                {
                    var roleName = await _userManager.GetRolesAsync(user);
                    var roleId = _roleService.GetRoleId(roleName.FirstOrDefault());
                    if (roleName.Any(r => r.Contains(Roles.ADMIN) || r.Contains(Roles.DESKOFFICER)))
                    {
                        return RedirectToAction("Index", "DashBoard");

                    }

                    return RedirectToAction("Index", "Properties"); // Default redirect after successful login
                }
                else
                {
                    _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.InvalidAccount, null);
                    return PartialView("Login", loginDTO);
                }
            }
            catch (Exception ex)
            {
                return SystemError(ex);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgetPassword(string? ReturnUrl)
        {
            ForgetPasswordDto model = new ForgetPasswordDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Forgetpassword(ForgetPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                string msg = ModelState.FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors.FirstOrDefault().ErrorMessage;
                string displayMsg = msg.Replace("'", "");
                _toastNotification.AddWarningToastMessage(displayMsg, null);
                return RedirectToAction("Forgetpassword");
            }

            //var employee = _context.NominalRolls.Where(a => a.IstAppointment == model.DateOfAppointment.ToString()
            //&& a.IPPISNO == model.Ippis).FirstOrDefault();
            //if (employee == null)
            //{
            //    _toastNotification.AddErrorToastMessage("Record not found !", null);
            //    return RedirectToAction("Forgetpassword");
            //}

            User signedUser = await _userManager.FindByNameAsync(model.Ippis);


            if (signedUser == null)
            {
                _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.IllegalOperation, null);
                return RedirectToAction("Forgetpassword");
            }
            // Assuming 'user' is the user who wants to reset their password
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(signedUser);

            var result = await _userManager.ResetPasswordAsync(signedUser, resetToken, model.Password);


            if (result.Succeeded)
            {
                // update the pwd change date to enable the user login
                signedUser.PwdChangedDate = DateTime.Now;
                signedUser.LastModified = DateTime.Now;
                await _userManager.UpdateAsync(signedUser);
                //var nroll = _context.EnrollmentStatuses.Where(u => u.IPPISNO == signedUser.Ippis).FirstOrDefault();

                //nroll.Status = EnrollStatus.InProgress.ToString();

                UserPasswordHistory passwordModel = new UserPasswordHistory();
                passwordModel.UserId = signedUser.Id;
                passwordModel.CreatedDate = DateTime.Now;
                passwordModel.HashPassword = ExtentionUtility.Encrypt(model.Password);
                passwordModel.CreatedBy = CurrentUser.UserId;

                _context.UserPasswordHistories.Add(passwordModel);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Password changed successfully !", null);
                return RedirectToAction("Login");
            }


            _toastNotification.AddSuccessToastMessage("Password change Failed !", null);
            return RedirectToAction("Forgetpassword");
        }
        

        [HttpGet("ResetPassword")]
        public async Task<IActionResult> ResetPassword(string userid, string token, string data)
        {
            LoginDTO model = new LoginDTO();

            if (userid == null || token == null || data == null)
            {
                _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.IllegalOperation, null);
                return RedirectToAction("login");
            }

            string ExpirationTime = ExtentionUtility.Decrypt(data);
            if (DateTime.Now > Convert.ToDateTime(ExpirationTime))
            {
                _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.ExpiredResetPasswordLink, null);
                return RedirectToAction("login");
            }

            User user = await _userManager.FindByIdAsync(userid);
            if (user == null)
            {
                _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.IllegalOperation, null);
                return PartialView("Login", model);
            }

            ResetChangePasswordViewModel modelResponse = new ResetChangePasswordViewModel();
            modelResponse.Email = user.Email;
            modelResponse.token = token;
            modelResponse.userid = userid;

            return PartialView(modelResponse);
        }

        [HttpPost("UpdatePassword")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePassword(PasswordChangeViewModel model)
        {

            if (!ModelState.IsValid)
            {
                string msg = ModelState.FirstOrDefault(x => x.Value.Errors.Any()).Value.Errors.FirstOrDefault().ErrorMessage;
                string displayMsg = msg.Replace("'", "");
                _toastNotification.AddWarningToastMessage(displayMsg, null);
                return PartialView("_FirstPassWord", model);
            }

            if (model.ConfirmPassword != model.NewPassword)
            {
                _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.PasswordMatchError, null);
                return PartialView("_FirstPassWord", model);

            }



            var hashPwd = ExtentionUtility.Encrypt(model.NewPassword);

            if (_context.UserPasswordHistories.Where(a => a.HashPassword == hashPwd && a.UserId == model.UserId).Count() > 0)
            {
                _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.ExistingPassword, null);
                return PartialView("_FirstPassWord", model);
            }

            User signedUser = await _userManager.FindByIdAsync(model.UserId);


            if (signedUser == null)
            {
                _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.IllegalOperation, null);
                return PartialView("_FirstPassWord", model);

            }

            
           

            var result = await _userManager.ChangePasswordAsync(signedUser,model.OldPassword, model.NewPassword);
            

            if (result.Succeeded)
            {
                // update the pwd change date to enable the user login
                signedUser.PwdChangedDate = DateTime.Now;
                signedUser.LastModified = DateTime.Now;
                await _userManager.UpdateAsync(signedUser);
                //var nroll = _context.EnrollmentStatuses.Where(u => u.IPPISNO == signedUser.Ippis).FirstOrDefault();

                //nroll.Status = EnrollStatus.InProgress.ToString();

                UserPasswordHistory passwordModel = new UserPasswordHistory();
                passwordModel.UserId = signedUser.Id;
                passwordModel.CreatedDate = DateTime.Now;
                passwordModel.HashPassword = ExtentionUtility.Encrypt(model.NewPassword);
                passwordModel.CreatedBy = CurrentUser.UserId;

                _context.UserPasswordHistories.Add(passwordModel);
                _context.SaveChanges();


                // SEND EMAIL 
                //var emailtemplate = await _emailManager.GetEmailTemplateByCode(EmailTemplateCode.USER_CHANGE_PASSWORD);
                //var emailTokens = new List<EmailTokenViewModel>
                //{
                //    new EmailTokenViewModel {  Token = EmailTokenConstants.FULLNAME,  TokenValue = $"{signedUser.FirstName} {signedUser.LastName}" },
                //    new EmailTokenViewModel {  Token = EmailTokenConstants.PORTALNAME,  TokenValue = _configuration["PortalName"] },
                //    new EmailTokenViewModel {  Token = EmailTokenConstants.USERNAME,  TokenValue = signedUser.Email },
                //    new EmailTokenViewModel {  Token = EmailTokenConstants.PASSWORD,  TokenValue = model.NewPassword },
                //    new EmailTokenViewModel {  Token = EmailTokenConstants.LogoURL,  TokenValue = _configuration["LogoURL"] }
                //};

                //bool mailresponse = await _emailManager.PrepareEmailLog(EmailTemplateCode.USER_CHANGE_PASSWORD, signedUser.Email,
                //                                    _configuration["cc"], "", emailTokens, CurrentUser.UserId, false);

                //if (mailresponse == true)
                //{
                //    _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.PasswordChanged, null);
                //    return RedirectToAction("Login");
                //}
                //else
                //{
                //    _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.OperationFailed, null);
                //    return PartialView("ResetPassword");
                //}

                _toastNotification.AddSuccessToastMessage(ResponseErrorMessageUtility.PasswordChanged, null);
                return RedirectToAction("Login");

            }
            else
            {
                _toastNotification.AddErrorToastMessage(result.Errors.FirstOrDefault().Description.ToString() + "Please try again", null);
                return PartialView("_FirstPassWord");
            }
        }

        [HttpGet]
        public IActionResult ForgetPassWordConfirm()
        {
            return View();
        }
        public async Task<IActionResult> LogOff()
        {
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();

            _toastNotification.AddInfoToastMessage(ResponseErrorMessageUtility.LogoutSuccessful, null);
            return RedirectToAction("Login", "CustomAccount");
        }

        public async Task<IActionResult> SessionExpired()
        {
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();

            _toastNotification.AddInfoToastMessage(ResponseErrorMessageUtility.SessionExpired, null);
            return RedirectToAction("Login", "CustomAccount");
        }

        #region Helpers Operation

        public bool IsAccountDeactivated(string userId)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            return user != null && !user.IsActive;
        }

        public string GetUserSessionToken(string userId)
        {
            var context = _httpContextAccessor.HttpContext;
            var sessionToken = context.Session.GetString($"UserSessionToken:{userId}");

            // Check if the user's account is deactivated
            bool isAccountDeactivated = IsAccountDeactivated(userId);

            if (isAccountDeactivated)
            {
                // Invalidate the user's session and sign them out
                InvalidateSessionToken(userId);
                sessionToken = null;
            }

            return sessionToken;
        }

        private void InvalidateSessionToken(string userId)
        {
            var context = _httpContextAccessor.HttpContext;

            // Invalidate or remove the session token from the session storage
            context.Session.Remove($"UserSessionToken:{userId}");

            // Sign out the user
            context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task CheckUserLogOff(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
                var isDeactivated = !user.IsActive;

                if (isDeactivated)
                {
                    string sessionToken = GetUserSessionToken(userId);

                    if (!string.IsNullOrEmpty(sessionToken))
                    {
                        InvalidateSessionToken(sessionToken);
                    }
                }
            }
        }

        private async Task PrepareSignInClaimsAdmin(User user, string roleId, string roleName)
        {
            var userClaims = (await _userManager.GetClaimsAsync(user)).ToList();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName,$"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, roleName),
                new Claim(ClaimTypes.Anonymous, roleName),
                new Claim(ClaimTypes.PostalCode, roleId),
            };
            User.AddIdentity(new ClaimsIdentity(claims));

            await _signInManager.SignInWithClaimsAsync(user, false, claims);
        }

        public void PrepareUserMenu(User user, string roleId)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == roleId);

            if (role != null)
            {
               // List<Permission> permissions = _permissionService.GetPermissionsByRoleId(roleId);
                //List<SidebarMenuViewModel> sidebarMenus = Filters.DynamicMenu.GenerateUrl(permissions);

               // Filters.SessionExtensions.SetObjectAsJson(HttpContext.Session, "MenuString", sidebarMenus);
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("RoleName", role.Name.ToLower());
                //HttpContext.Session.SetString("Menus", JsonConvert.SerializeObject(permissions));
            }
        }

        //private string SetUserPermissions(User User, string roleId)
        //{
        //    try
        //    {
        //        List<Permission> permissions = _permissionService.GetPermissionsByRoleId(roleId);

        //        string userPermissions = "";
        //        if (permissions != null)
        //        {
        //            int i = 0;
        //            foreach (Permission permission in permissions)
        //            {
        //                if (i == 0)
        //                {
        //                    userPermissions = permission.PermissionCode + ",";
        //                }
        //                else
        //                {
        //                    userPermissions = userPermissions + permission.PermissionCode + ",";
        //                }

        //                i++;
        //            }
        //        }

        //        return userPermissions;
        //    }
        //    catch (Exception ex)
        //    {
        //        return string.Empty;
        //    }
        //}

        public RedirectToActionResult SystemError(Exception ex)
        {
            _errorLogger.LogError(ex, GetControllerAndActionName(this));
            _toastNotification.AddErrorToastMessage(ResponseErrorMessageUtility.OperationFailed_Ex, null);

            ModelState.Clear();

            return RedirectToAction(nameof(Login));
        }
        #endregion
    }
}