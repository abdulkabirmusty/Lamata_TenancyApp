using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.Payment
{
	public class RemitaSplitPaymentRequest
	{
		public string merchantId { get; set; }
		public string serviceTypeId { get; set; }
		public string orderId { get; set; }
		public string amount { get; set; }
		public string hash { get; set; }
		public string apiKey { get; set; }
		public string payerName { get; set; }
		public string payerEmail { get; set; }
		public string payerPhone { get; set; }
		public string description { get; set; }
		public List<RemitaSplitLineItems> lineItems { get; set; }
	}
}
