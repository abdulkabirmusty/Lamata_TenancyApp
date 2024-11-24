using Microsoft.AspNetCore.Http;
using Tenant_App.Models.Domains.Account;
using Tenant_App.Utilities.Enrollment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class PersonalDto
    {
        public Guid? Id { get; set; }
        [IgnorePropertyCheck]
        public string? PassportImagePath { get; set; }
        [IgnorePropertyCheck]
        public PassportDto passportDto { get; set; }
        public string? IPPISNo { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; } // Optional
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? MaritalStatus { get; set; }
        public string? PhoneNo { get; set; }
        public string? CurrentAddress { get; set; }
        public string? PermanentAddress { get; set; }
        public string? LGA { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? StateOfOrigin { get; set; }
        public string? Nationality { get; set; }
        public string? UserId { get; set; }
    }

}
