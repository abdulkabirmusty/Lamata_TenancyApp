﻿namespace Tenant_App.Utilities.AuthenticationUtility
{
    public class AuthenticationSettings
    {
        public string Secret { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public int JwtExpires { get; set; }
    }
}
