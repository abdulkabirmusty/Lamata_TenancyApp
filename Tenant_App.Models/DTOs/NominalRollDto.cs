using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class NominalRollDto
    {
        public Guid Id { get; set; }
        public string SN { get; set; }
        public string FNO { get; set; }
        public string IPPISNO { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Sex { get; set; }
        public string Rank { get; set; }
        public string HighestQualification { get; set; }
        public string DateOfBirth { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public string SenetorialDistrict { get; set; }
        public string IstAppointment { get; set; }
        public string DateInNabteb { get; set; }
        public string ConfirmationDate { get; set; }
        public string PresentAppointment { get; set; }
        public string CONR { get; set; }
        public string UnknownProperty { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public string EmailAddress { get; set; }
    }
}
