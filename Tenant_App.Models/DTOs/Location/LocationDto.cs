using Tenant_App.Models.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs.Location
{
    public class LocationDto : BaseObjectDataIntegrity
    {
        public string LocationName { get; set; }
        public string Code { get; set; }
    }
}
