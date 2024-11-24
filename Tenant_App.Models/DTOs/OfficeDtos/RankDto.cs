using Tenant_App.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace Tenant_App.Models.DTOs.OfficeDtos
{
    public class RankDto : BaseObjectDataIntegrity
    {
        [Required(ErrorMessage = "Rank is required")]
        [DisplayName("Rank")]
        public string RankName { get; set; }
    }
}
