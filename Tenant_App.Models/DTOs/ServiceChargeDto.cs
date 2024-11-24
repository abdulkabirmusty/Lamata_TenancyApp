using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
	public class ServiceChargeDto
	{
		public Guid Id { get; set; }
		public decimal Amount { get; set; }
		public DateTime CreatedDate { get; set; }
		public Guid FrequencyId { get; set; }
		public Guid ServiceTypeId { get; set; }
		public Guid PropertyTypeId { get; set; }
		public string UserId { get; set; }
		public string PropertyName { get; set; }
		public string ServiceDescription { get; set; }
		public FrequencyType FrequencyDescription { get; set; }
		public string PropertyTypeName { get; set; }
	}


	public class ServiceChargePaymentDto
	{
		public Guid Id { get; set; }
		public string CustomerName { get; set; }
		public Guid ServiceChargeId { get; set; }
		public string UserId { get; set; }
		public Guid PropertyId { get; set; }
		public Guid FrequencyId { get; set; }
		public string ServiceDescription { get; set; }
		public string FrequencyDescription { get; set; }
		public decimal AmountToPay { get; set; }
		public string RRRCode { get; set; }
		public string PaymentStatus { get; set; }
		//public string ServiceChargeId { get; set; }
		//public string PropertyId { get; set; }
		//public string UserId { get; set; }
		public DateTime PaymentDate { get; set; }
		public DateTime NextDueDate { get; set; }
	}

	public class UserServiceChargeDto
	{
		public Guid ServiceChargeId { get; set; }
		public Guid PropertyId { get; set; }
		public string PropertiesName { get; set; }
		public string PropertiesAddress { get; set; }
		public decimal Amount { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime ExpiryDate { get; set; }
		public string UserId { get; set; }
		public string ServiceTypeName { get; set; }
		public string PaymentStatus { get; set; }
		public FrequencyType Tenure { get; set; }
	}
}
