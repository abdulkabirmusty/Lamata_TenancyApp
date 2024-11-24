using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.Account;
using Tenant_App.Models.DataObjects.CooperateTenantDtos;
using Tenant_App.Models.Domains.CooperateTenantDomain;

namespace Tenant_App.Services.Contract.CooperateTenantContract
{
    public interface ICooperateTenant
    {
        public CooperateTenant GetById(Guid id);
        Task<string> CreateCooperateTenant(CooperateTenantRegDto cooperateTenantRegDTO);
        public CooperateTenantDto ViewCoperateTenant(Guid id);
        public List<CooperateTenantDto> GetAllCooperateTenant();
        public List<CooperateTenantDto> GetAcceptedCooperateTenant();
        Task<string> AcceptCooperateTenants(List<Guid> cooperateTenantId, string adminUserId);
        Task<string> RejectCooperateTenants(List<Guid> cooperateTenantId, string adminUserId);
        //public byte[] DownloadContestantInfo(string membershipNumber);
    }
}
