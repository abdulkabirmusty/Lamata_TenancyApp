using System;
using System.Collections.Generic;
using System.Text;
using Tenant_App.Models.Domains;

namespace Tenant_App.Models.DataObjects.IndividualTenantDtos
{
    public class IndividualTenantDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CurrentAddress { get; set; }
        public string? HomePhoneNo { get; set; }
        public string? WorkPhoneNo { get; set; }
        public bool? Status { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string Sex { get; set; }
        public string RentDuration { get; set; }
        public string Nationality { get; set; }
        public string? StateOfOrigin { get; set; }
        public string IdentityType { get; set; }
        public string IdentityAttach { get; set; }
        public string SignaturePath { get; set; }
        public string PassportPath { get; set; }
        public string nextOfKinFullName { get; set; }
        public string Relationship { get; set; }
        public string NextOfKinAddress { get; set; }
        public string NextOfKinEmail { get; set; }
        public string NextOfKinMobilePhoneNo { get; set; }
        public string NextOfKinWorkPhoneNo { get; set; }
        public string PreviousAddress { get; set; }
        public string LengthOfTime { get; set; }
		public List<RefereeDto> Referees { get; set; }
		public bool IsConsent { get; set; }
		public string BankName { get; set; }
		public string BankAccountNo { get; set; }
		public string AccountName { get; set; }
		public string TypeOfBusiness { get; set; }

	}

	public class RefereeDto
	{
		public string FullName { get; set; }
		public string Relationship { get; set; }
		public string MobileNo { get; set; }
		public string SignaturePath { get; set; }
	}

   
}
