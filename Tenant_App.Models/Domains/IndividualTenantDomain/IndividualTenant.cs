using Tenant_App.Models.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.IndividualTenantDomain
{
    public class IndividualTenant : BaseObject
    {
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
        public Guid NextOfKinId { get; set; }
        public virtual NextOfKin NextOfKin { get; set; }
        public Guid RentalHistoryId { get; set; }
        public virtual RentalHistory RentalHistory { get; set; }
        public ICollection<Referee> Referees { get; set; } = new List<Referee>();
		public bool IsConsent { get; set; }
        public string BankName { get; set; }
        public string BankAccountNo { get; set; }
        public string AccountName { get; set; }
        public string TypeOfBusiness { get; set; }
    }
    public class NextOfKin : BaseObject
    {
        public string FullName { get; set; }
        public string Relationship { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MobilePhoneNo { get; set; }
        public string WorkPhoneNo { get; set; }
    }

    public class RentalHistory : BaseObject
    {
        public string PreviousAddress { get; set; }
        public string LengthOfTime { get; set; }
    }
}
