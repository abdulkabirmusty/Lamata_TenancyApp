using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.DamageDtos;
using Tenant_App.Models.DataObjects.PropertyDtos;

namespace Tenant_App.Services.Contract.DamagesContract
{
    public interface IDamage
    {
        Task<FetchDamageDto> GetDamagesById(Guid id);
        Task<string> CreateDamageReport(DamageDto obj);
        public List<FetchDamageDto> GetAllDamages();
        public List<FetchDamageDto> GetAllDamages(string userId);
        Task<string> UpdateDamage(DamageDto obj, Guid id);
        Task<string> UpdateAdminComment(DamageDto obj, Guid id);
        Task<bool> DeleteDamage(Guid id);
    }
}
