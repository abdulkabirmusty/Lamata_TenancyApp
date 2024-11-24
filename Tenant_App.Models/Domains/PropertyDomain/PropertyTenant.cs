using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Tenant_App.Models.Domains.PropertyDomain
{
    public class PropertyTenant: BaseObject
    {
       public string PropertiesName { get; set; }
       public string PropertiesAddress { get; set; }
       public string propertiesDescription { get; set; }
       public string PropertiesDuration { get; set; }
       public decimal Amount { get; set; }
       public string CompanyName { get; set; }
       public int ApprovalStatus { get; set;}
       public DateTime startDate { get; set; }
       public DateTime expiryDate { get; set; }
       public Guid PropertiesId { get; set; }
       public string UserID { get; set; }
       public string Comment { get; set; }
       public string Size { get; set; }
       public string Dimension { get; set; }
       public bool IsPaid { get; set; }
    }
}
