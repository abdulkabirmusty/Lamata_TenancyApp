using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.ServiceType
{
	public class ServiceChargePayment : BaseObject
	{
		public string CustomerName { get; set; }
		public Guid ServiceTypeId { get; set; }
		public Guid PropertyTypeId { get; set; }
		public Guid FrequencyId { get; set; }
		public decimal AmountToPay { get; set; }
		public string RRRCode { get; set; }
		public string PaymentStatus { get; set; }
		public DateTime PaymentDate { get; set; }
		public DateTime NextDueDate { get; set; }

		public ServiceType ServiceType { get; set; }
		public Frequency Frequency { get; set; }
	}
}
