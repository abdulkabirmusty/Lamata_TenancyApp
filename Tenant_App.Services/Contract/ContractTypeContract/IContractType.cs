using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.Account;
using Tenant_App.Models.DataObjects.ContractTypeDtos;
using Tenant_App.Models.DataObjects.CooperateTenantDtos;
using Tenant_App.Models.Domains.ContractTypeDomain;
using Tenant_App.Models.Domains.CooperateTenantDomain;

namespace Tenant_App.Services.Contract.ContractTypeContract
{
    public interface IContractType
    {
        Task<ContractTypeDto> GetById(Guid id);
        Task<string> CreateContractType(ContractTypeDto obj);
        public List<ContractTypeDto> GetAllContractType();
        Task<string> UpdateContractType(ContractTypeDto obj, Guid id);
        Task<bool> DeleteContractType(Guid id);
    }
}
