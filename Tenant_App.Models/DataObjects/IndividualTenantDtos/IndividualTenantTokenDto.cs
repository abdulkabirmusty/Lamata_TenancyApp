using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DataObjects.IndividualTenantDtos
{
    public class IndividualTenantTokenDto
    {
        public string TokenName { get; set; }
        public string Token { get; set; }
        public string TokenValue { get; set; }
    }

    public class IndividualTenantTokenConstant
    {
        public const string FIRSTNAME = "#FirstName";
        public const string LASTNAME = "#LastName";
        public const string CURRENTADDRESS = "#CurrentAddress";
        public const string HOMEPHONENO = "#HomePhoneNo";
        public const string WORKPHONENO = "#WorkPhoneNo";
        public const string DOB = "#DOB";
        public const string SEX = "#Sex";
        public const string RENTDURATION = "#RentDuration";
        public const string EMAIL = "#Email";
        public const string STATEOFORIGIN = "#StateOfOrigin";
        public const string NATIONALITY = "#Nationality";
        public const string IDENTITYTYPE = "#IdentityType";
        public const string IDENTITYATTACH = "#IdentityAttach";
        public const string PASSPORTPATH = "#PassportPath";
        public const string SIGNATUREPATH = "#SignaturePath";
        public const string NEXTOFKINFULLNAME = "#NextOfKinFullName";
        public const string RELATIONSHIP = "#Relationship";
        public const string NEXTOFKINADDRESS = "#NextOfKinAddress";
        public const string NEXTOFKINEMAIL = "#NextOfKinEmail";
        public const string NEXTOFKINMOBILEPHONENO = "#NextOfKinMobilePhoneNo";
        public const string PREVIOUSADDRESS = "#PreviousAddress";
        public const string LENGTHOFTIME = "#LengthOfTime";
    }
}
