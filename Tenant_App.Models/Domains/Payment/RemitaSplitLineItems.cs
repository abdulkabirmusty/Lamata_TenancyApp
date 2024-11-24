using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.Payment
{
	public class RemitaSplitLineItems
	{
		public string lineItemsId { get; set; }
		public string beneficiaryName { get; set; }
		public string beneficiaryAccount { get; set; }
		public string bankCode { get; set; }
		public string beneficiaryAmount { get; set; }
		public string deductFeeFrom { get; set; }
		public string status { get; set; }
	}
}
