using System;
using Tenant_App.Utilities.PasswordUtility;
using System.ComponentModel.DataAnnotations;

namespace Tenant_App.Models.DataObjects.Account
{
    [PropertiesMustMatch("Password", "ConfirmPassword", ErrorMessage = "Password and Confirm Password must match.")]
    [Serializable]
    public class PasswordInAppResetDTO
    {
        [Required(ErrorMessage ="Please fill in all fields for the user")]
        public string CurrentPassword { get; set; }

        // [Required(ErrorMessage = "Please input the password for the user")]
        public string Password { get; set; }
        //[Required(ErrorMessage = "Please confirm the current password for the user")]
        public string ConfirmPassword { get; set; }
       // public string UserEmail { get; set; }
    }
}
