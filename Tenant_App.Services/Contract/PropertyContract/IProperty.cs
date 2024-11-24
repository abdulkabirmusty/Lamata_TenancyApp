using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.ContractTypeDtos;
using Tenant_App.Models.DataObjects.PropertyDtos;
using Tenant_App.Models.Domains.ContractTypeDomain;
using Tenant_App.Models.Domains.PropertyDomain;

namespace Tenant_App.Services.Contract.PropertyContract
{
    public interface IProperty
    {
        Task<PropertyRegDto> GetPropertyById(Guid id);
        Task<string> CreateProperty(PropertyRegDto obj);
        public List<PropertyDto> GetAllProperty();
        Task<string> UpdateProperty(PropertyRegDto obj, Guid id);
        Task<bool> DeleteProperty(Guid id);
        Task<bool> UpdateStatus(Guid id);
    }
}
