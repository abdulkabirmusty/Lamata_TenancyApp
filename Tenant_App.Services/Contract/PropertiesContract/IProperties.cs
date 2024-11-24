using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.PropertyDtos;

namespace Tenant_App.Services.Contract.PropertiesContract
{
    public interface IProperties
    {
        Task<PropertyRegDto> GetPropertyById(Guid id);
        public List<PropertyDto> GetAllProperty();
    }
}
