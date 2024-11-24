using Tenant_App.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace Tenant_App.Models.DTOs.OfficeDtos
{
    public class DepartmentDto : BaseObjectDataIntegrity
    {
        [Required(ErrorMessage = "Department Name is required")]
        [DisplayName("Department Name")]
        public string DepartmentName { get; set; }
        public string Code { get; set; }
        public Guid Id { get; set; }
    }
}
