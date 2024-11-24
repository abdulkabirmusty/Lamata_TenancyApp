using System;
using System.Collections.Generic;
using System.Text;
using Tenant_App.Models.Domains;

namespace Tenant_App.Models.DataObjects.ContractTypeDtos
{
    public class ContractTypeDto : BaseObjectDataIntegrity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
