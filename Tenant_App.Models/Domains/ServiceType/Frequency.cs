using System;
using System.Collections.Generic;
using System.Text;
using Tenant_App.Models.DTOs;

namespace Tenant_App.Models.Domains.ServiceType
{
	public class Frequency : BaseObject
	{
		public string FrequencyDesc { get; set; }
		public FrequencyType FrequencyType { get; set; }
	}
}
