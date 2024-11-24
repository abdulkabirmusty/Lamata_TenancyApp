using Tenant_App.Models.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace Tenant_App.Models.DTOs.OfficeDtos
{
	public class ConrDto : BaseObjectDataIntegrity
	{
		[Required(ErrorMessage = "Conraiss is required")]
		[DisplayName("Conraiss")]
		public string ConrName { get; set; }
		[Required(ErrorMessage = "Code is required")]
		[DisplayName("Code")]
		public string Code { get; set; }
	}
}
