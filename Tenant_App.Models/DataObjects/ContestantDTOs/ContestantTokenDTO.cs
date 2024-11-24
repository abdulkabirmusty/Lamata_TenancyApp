using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DataObjects.ContestantDTOs
{
    public class ContestantTokenDTO
    {
        public string TokenName { get; set; }
        public string Token { get; set; }
        public string TokenValue { get; set; }
    }

    public class ContestantTokenConstants
    {
        public const string FIRSTNAME = "#FirstName";
        public const string LASTNAME = "#LastName";
        public const string EMAIL = "#Email";
        public const string MEMBERSHIP_NUMBER = "#MembershipNumber";
        public const string MEMBERSHIP_GRADE = "#MembershipGrade";
        public const string YEARS_ON_MEMBERSHIP_GRADE = "#YearsOnMembershipGrade";
        public const string PHONE_NUMBER = "#PhoneNumber";
        public const string ADDRESS = "#Address";
        public const string NATIONALITY = "#Nationality";
        public const string POSITION = "#Position";
        public const string BRIEF_BIO = "#BriefBio";
        public const string PASSPORTPATH = "#PassportPath";
        public const string SIGNATUREPATH = "#SignaturePath";
    }
}
