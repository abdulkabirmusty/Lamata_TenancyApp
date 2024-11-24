using Tenant_App.Models.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DataObjects.ContestantDTOs
{
    public class ContestantDTO
    {
        public Guid Id {  get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MembershipNumber { get; set; }
        public string MembershipGrade { get; set; }
        public string YearsOnMembershipGrade { get; set; }
        public bool? Status { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string SignaturePath { get; set; }
        public string PassportPath { get; set; }
        public string Nationality { get; set; }
        public string BriefBio { get; set; }
        public string PositionName { get; set; }
        public string SponsorLetterPath { get; set; }
        public string CoSponsorLetterPath { get; set; }
        public string ElectoralCommitteeLetterPath { get; set; }
        public string OtherDocumentPath { get; set; }

    }
}
