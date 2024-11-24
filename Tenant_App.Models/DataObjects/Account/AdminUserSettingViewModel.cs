using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace Tenant_App.Models.DataObjects.Account
{
	public class AdminUserSettingViewModel 
	{
		public string Id { get; set; }

		[Required(ErrorMessage = "* First name required")]
		[DisplayName("First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "* Surname  required")]
		[DisplayName("Last Name")]
		public string LastName { get; set; }

		[DisplayName("User Name")]
		public string UserName { get; set; }
		public bool IsActive { get; set; }
		
		[Required(ErrorMessage = "* Email required")]
		[DisplayName("Email")]
		[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is not valid.")]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[DisplayName("Password")]
		public string Password { get; set; }
		public DateTime? LastModified { get; set; }
		public string ModifiedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public string CreatedBy { get; set; }
		public bool IsDeleted { get; set; }
	}
}
