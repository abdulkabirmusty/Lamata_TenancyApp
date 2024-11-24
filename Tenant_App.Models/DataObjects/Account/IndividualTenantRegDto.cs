using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using Tenant_App.Models.DataObjects.IndividualTenantDtos;
using Microsoft.AspNetCore.Http;

namespace Tenant_App.Models.DataObjects.Account
{
    public class IndividualTenantRegDto
    {
        [Required(ErrorMessage = "* First Name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "* Last Name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "* Current Address is required")]
        [DisplayName("Current Address")]
        public string CurrentAddress { get; set; }
        [Required(ErrorMessage = "* Home Phone Number is required")]
        [DisplayName("Home Phone Number")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.PhoneNumber)]
        public string? HomePhoneNo { get; set; }
        [Required(ErrorMessage = "* Work Phone Number is required")]
        [DisplayName("Work Phone Number")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.PhoneNumber)]
        public string? WorkPhoneNo { get; set; }
        [Required(ErrorMessage = "* Email required")]
        [DisplayName("Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "* Date of Birth is required")]
        [DisplayName("Date of Birth")]
        public string DOB { get; set; }
        [Required(ErrorMessage = "* Sex is required")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "* Rent Duration is required")]
        [DisplayName("Rent Duration")]
        public string RentDuration { get; set; }
        [Required(ErrorMessage = "* Nationality is required")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "* State of Origin is required")]
        [DisplayName("State of Origin")]
        public string? StateOfOrigin { get; set; }
        [Required(ErrorMessage = "* Identity Type is required")]
        public string IdentityType { get; set; }
        [Required(ErrorMessage = "* IdentityAttach is required")]
        public IFormFile Identityfile { get; set; }
        [Required(ErrorMessage = "* Signature is required")]
        public IFormFile Signature { get; set; }
        [Required(ErrorMessage = "* Passport is required")]
        public IFormFile Passport { get; set; }
        [Required(ErrorMessage = "* Next Of Kin Name is required")]
        [DisplayName("Next Of Kin Name")]
        public string nextOfKinFullName { get; set; }
        [Required(ErrorMessage = "* Relationship is required")]
        public string Relationship { get; set; }
        [Required(ErrorMessage = "* Next Of Kin Address is required")]
        [DisplayName("Next Of Kin Address")]
        public string NextOfKinAddress { get; set; }
        [Required(ErrorMessage = "* Next of Kin Email required")]
        [DisplayName("Next of Kin Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string NextOfKinEmail { get; set; }
        [Required(ErrorMessage = "* Next Of Kin Mobile Phone No is required")]
        [DisplayName("Next Of Kin Mobile Phone No")]
        public string NextOfKinMobilePhoneNo { get; set; }
        [Required(ErrorMessage = "* Next Of Kin Work Phone No is required")]
        [DisplayName("Next Of Kin Work Phone No")]
        public string NextOfKinWorkPhoneNo { get; set; }
        [Required(ErrorMessage = "* Previous Address is required")]
        [DisplayName("Previous Address")]
        public string PreviousAddress { get; set; }
        [Required(ErrorMessage = "* Length of Time is required")]
        [DisplayName("Duration")]
        public string LengthOfTime { get; set; }
		public bool IsConsent { get; set; }
		public string BankName { get; set; }
		public string BankAccountNo { get; set; }
		public string AccountName { get; set; }
		public string TypeOfBusiness { get; set; }
		public List<RefereeeDto> Refereees { get; set; } = new List<RefereeeDto>();

	}

	public class RefereeeDto
    {
        [Required(ErrorMessage = "* Referee Name is required")]
        [DisplayName("Referee Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "* Relation is required")]
        [DisplayName("Relationship")]
        public string Relationship { get; set; }
        [Required(ErrorMessage = "* Phone Number is required")]
        [DisplayName("Phone number")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "* Signature of Time is required")]
        public IFormFile Signature { get; set; }
    }
}
