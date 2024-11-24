using Tenant_App.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace Tenant_App.Models.DTOs.OfficeDtos
{
    public class DesignationDto : BaseObjectDataIntegrity
    {
        [Required(ErrorMessage = "Designation Name is required")]
        [DisplayName("Designation Name")]
        public string DesignationName { get; set; }
    }
}
