using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.Payment
{
	public class RemitaSettings
	{
		public string ServiceTypeId { get; set; }
		public string MerchantId { get; set; }
		public string ApiKey { get; set; }
		public string PublicKey { get; set; }
		public string SecretKey { get; set; }
		public string RrrTransactionURL { get; set; }
		public string XmlUrlStatus { get; set; }
		public string RrrGatewayUrl { get; set; }
		public string RrrCheckStatus { get; set; }
		public string RemitaUrl { get; set; }
	}
}
