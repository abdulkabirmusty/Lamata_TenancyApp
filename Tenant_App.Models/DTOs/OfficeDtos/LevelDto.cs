using Tenant_App.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace Tenant_App.Models.DTOs.OfficeDtos
{
    public class LevelDto : BaseObjectDataIntegrity
    {
        [Required(ErrorMessage = "Level is required")]
        [DisplayName("Level")]
        public string LevelName { get; set; }
    }
}
