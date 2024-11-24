using Tenant_App.Models.DataObjects.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.DataObjects.Account;
using Tenant_App.Models.DataObjects.IndividualTenantDtos;
using Tenant_App.Models.Domains.IndividualTenantDomain;

namespace Tenant_App.Services.Contract.IndividualTenantContract
{
	public interface IIndividualTenant
	{
		public IndividualTenant GetById(Guid id);
		Task<string> CreateIndividualTenant(IndividualTenantRegDto individualTenantDto);
		public IndividualTenantDto ViewIndividualTenant(Guid id);
		public List<IndividualTenantDto> GetAllIndividualTenant();
		public List<IndividualTenantDto> GetApprovedTenant();
		Task<string> AcceptIndividual(List<Guid> IndividualTenantId, string adminUserId);
		Task<string> RejectIndividual(List<Guid> IndividualTenantId, string adminUserId);
		public byte[] DownloadTenantInfo(string IndividualTenantId);
	}
}
