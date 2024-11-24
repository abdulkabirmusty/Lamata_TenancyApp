using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Tenant_App.Models.Domains
{
    public class BaseObject
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
        public bool? IsDeleted { get; set; } = false;

        public string IPAddress { get; set; } = Tenant_App.Utilities.Common.GetLocalIPAddress();

    }

    public class BaseObjectDataIntegrity
    {
        public Guid Id { get; set; } = new Guid();
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public bool IsActive { get; set; }
        public string DataIntegrity { get; set; }
        public string ResponseMessage { get; set; }

    }
}
