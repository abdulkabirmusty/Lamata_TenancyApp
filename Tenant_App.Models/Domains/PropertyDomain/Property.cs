using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.PropertyDomain
{
    public class Property : BaseObject
    {
        public string PropertyName { get; set; }
        public string PropertyDesciption { get; set; }
        public string PropertyInformation { get; set; }
        public string PropertyAddress { get; set; }
        public string DurationAllowed { get; set; }
        public decimal Amount { get; set; }
        public string PropertyImagePath { get; set; }
        public string RoomNumber { get; set; }
        public int AvailableRoom { get; set; }
        public int RemainingRoom { get; set; }
        public string Size { get; set; }
        public string Dimension { get; set; }

    }
}
