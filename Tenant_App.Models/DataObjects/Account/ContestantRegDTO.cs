using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Tenant_App.Utilities.Document;
using Microsoft.AspNetCore.Http;
using Tenant_App.Models.DataObjects.DocumentDTOs;

namespace Tenant_App.Models.DataObjects.Account
{
    public class ContestantRegDTO
    {
        [Required(ErrorMessage = "* First Name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Last Name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "* Membership Number is required")]
        [DisplayName("Membership Number")]
        public string MembershipNumber { get; set; }

        [Required(ErrorMessage = "* Membership Grade is required")]
        [DisplayName("Membership Grade")]
        public string MembershipGrade { get; set; }

        [Required(ErrorMessage = "* Number of Years on Membership Grade is required")]
        [DisplayName("Number of Years on Membership Grade")]
        public string YearsOnMembershipGrade { get; set; }

        [Required(ErrorMessage = "* Email required")]
        [DisplayName("Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "* Phone Number is required")]
        [DisplayName("Phone Number")]
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Invalid Mobile Number.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "* Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "* Signature is required")]
        public IFormFile Signature { get; set; }

        [Required(ErrorMessage = "* Passport is required")]
        public IFormFile Passport { get; set; }

        [Required(ErrorMessage = "* Position is required")]
        public Guid PositionId { get; set; }

        [Required(ErrorMessage = "* Nationality is required")]
        public string Nationality { get; set; }

        [DisplayName("Brief Bio")]
        [Required(ErrorMessage = "* Brief Bio is required")]
        public string BriefBio { get; set; }


		[Required(ErrorMessage = "* Sponsor is required")]
		[DisplayName("Sponsor Letter")]
		public IFormFile SponsorLetter { get; set; }

		[Required(ErrorMessage = "* Co-Sponsor is required")]
		[DisplayName("Co-Sponsor Letter")]
		public IFormFile CoSponsorLetter { get; set; }

		[Required(ErrorMessage = "* Electoral Commitee Letter is required")]
		[DisplayName("Electoral Committee Letter")]
		public IFormFile ElectoralCommitteeLetter { get; set; }

		[DisplayName("Other Documents")]
		public IFormFile OtherDocument { get; set; }

	}
}
