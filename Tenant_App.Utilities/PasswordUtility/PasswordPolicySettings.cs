﻿namespace Tenant_App.Utilities.PasswordUtility
{
    public class PasswordPolicySettings
    {
        public bool RequireUppercase { get; set; }
        public bool RequireNonAlphanumeric { get; set; }
        public bool RequireLowercase { get; set; }
        public int RequiredUniqueChars { get; set; }
        public int RequiredLength { get; set; }
        public bool RequireDigit { get; set; }
    }
}
