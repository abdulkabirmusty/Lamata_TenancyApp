using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Tenant_App.Models.DataObjects.Account
{
    public class CooperateTenantRegDto
    {
        [Required(ErrorMessage = "* Cooperate Name is required")]
        [DisplayName("Cooperate Name")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "* Company Email required")]
        [DisplayName("Company Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string CooperateEmail { get; set; }
        [Required(ErrorMessage = "* Address is required")]
        [DisplayName("Address")]
        public string Address { get; set; }
		public string CACRegNo { get; set; }
		public string TIN { get; set; }
		[Required(ErrorMessage = "* Phone Number is required")]
        [DisplayName("Phone Number")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhoneNo { get; set; }
        [Required(ErrorMessage = "* Personal Contact Number is required")]
        [DisplayName("Personal Contact Number")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.PhoneNumber)]
        public string PersonalContact { get; set; }
        [Required(ErrorMessage = "* FormC07 is required")]
        [DisplayName("FormC07")]
        public IFormFile FormC07 { get; set; }
        [Required(ErrorMessage = "* Bank Refernce is required")]
        [DisplayName("Bank Reference")]
        public IFormFile BankReference { get; set; }
        [Required(ErrorMessage = "* Director Profile is required")]
        [DisplayName("Director Profile")]
        public IFormFile DirectorProfile { get; set; }
		public bool IsConsent { get; set; }
	}
}
