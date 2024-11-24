using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tenant_App.Models.Domains.Account
{
    public class UserRole : IdentityUserRole<string>
    {
    }
}
