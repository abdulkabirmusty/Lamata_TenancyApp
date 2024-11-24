using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.EmployeeProfile
{
    using Tenant_App.Models.Domains.Account;
    using System;

    public class PersonalDetail
    {
        public Guid Id { get; private set; }
        public string? PassportImagePath { get; set; }
        public string IPPISNo { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; } // Optional
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string? MaritalStatus { get; set; }
        public string? PhoneNo { get; set; }
        public string? CurrentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? LGA { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? Ippis { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }

}
