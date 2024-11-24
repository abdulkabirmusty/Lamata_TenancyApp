using Microsoft.AspNetCore.Identity;
using Tenant_App.Models.Domains.EmployeeProfile;
using Tenant_App.Models.Domains.File;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Tenant_App.Models.Domains.Account
{
	public class User : IdentityUser<string>
	{
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public bool FirstLogin { get; set; } = true;
		public string ImagePath { get; set; } = string.Empty;
		public bool PaymentConfirm { get; set; }
		public DateTime? PwdChangedDate { get; set; }
		public DateTime? LastModified { get; set; }
		public string? ModifiedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public string? CreatedBy { get; set; }
		public bool IsDeleted { get; set; }
		public bool IsActive { get; set; }
		public int Status { get; set; }
		public bool IsApproved { get; set; } = false;

		public User()
		{
			CreatedDate = DateTime.Now;
			IsDeleted = false;
			IsActive = true;
			PaymentConfirm = false;
		}
	}

}
