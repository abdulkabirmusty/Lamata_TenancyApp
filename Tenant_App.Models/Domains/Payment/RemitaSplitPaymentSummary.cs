using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.Payment
{
	public class RemitaSplitPaymentSummary
	{
		public string PublicKey { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Amount { get; set; }
		public string Narration { get; set; }
		public string OrderId { get; set; }
		public string RRR { get; set; }
		public string UserId { get; set; }
		public string TechnologyFee { get; set; }
	}
}
