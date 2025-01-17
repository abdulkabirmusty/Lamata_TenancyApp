﻿using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Tenant_App.Utilities.AuthenticationUtility.UserAgent;

namespace Tenant_App.Utilities.AuthenticationUtility.AuthUser
{
    public class AuthUser : IAuthUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AuthUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
        public string EmailAddress => _accessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;

        //public long BranchID => _accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        public bool Authenticated => _accessor.HttpContext.User.Identity.IsAuthenticated;

        public string UserId => "3";
        //public string UserId => _accessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        
        public string IPAddress => _accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

        public string Browser => GetUserAgents().Browser.Name;

       
      
        private UserAgentModel GetUserAgents()
        {
            string useragent = _accessor.HttpContext.Request.Headers[HeaderNames.UserAgent].ToString();
            UserAgentModel result = new UserAgentModel(useragent);
            {
                return result;
            }
        }

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public string OS()
        {
            throw new NotImplementedException();
        }

        public string OSVersion()
        {
            throw new NotImplementedException();
        }
    }
}
