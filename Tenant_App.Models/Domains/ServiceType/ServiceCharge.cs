using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.ServiceType
{
	public class ServiceCharge : BaseObject
	{
		public Guid ServiceTypeId { get; set; }
		public Guid PropertyTypeId { get; set; }
		public Guid FrequencyId { get; set; }
		public decimal Amount { get; set; }

		public ServiceType ServiceType { get; set; }
		public Frequency Frequency { get; set; }
		//public Property Property { get; set; }
	}

	public class ServiceChargeViewModel
	{
		public Guid Id { get; set; }
		public decimal Amount { get; set; }
		public DateTime CreatedDate { get; set; }
		public Guid FrequencyId { get; set; }
		public Guid ServiceTypeId { get; set; }
		public Guid PropertyTypeId { get; set; }
		public string PropertyName { get; set; }
	}
}
