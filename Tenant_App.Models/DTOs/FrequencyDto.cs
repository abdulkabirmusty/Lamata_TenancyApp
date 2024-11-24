using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
	public class FrequencyDto
	{
		public Guid Id { get; set; }
		public string FrequencyDesc { get; set; }
		public FrequencyType FrequencyType { get; set; }
		public DateTime CreatedDate { get; set; }
		public string FrequencyTypeName { get; set; }
		public bool IsActive { get; set; }
	}

	public class FrequencyViewModel
	{
		public FrequencyType FrequencyType { get; set; }
		public string FrequencyDesc { get; set; }
		public bool IsActive { get; set; } = true;
	}

	public enum FrequencyType
	{
		Monthly,
		Quarterly,
		Yearly,
		Weekly,
		Daily
	}

}
