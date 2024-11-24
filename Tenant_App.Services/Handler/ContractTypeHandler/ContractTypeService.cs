using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.ContractTypeDtos;
using Tenant_App.Models.Domains.ContractTypeDomain;
using Tenant_App.Services.Contract.ContractTypeContract;
using Tenant_App.Services.Contract.EmailMessaging;
using Tenant_App.Services.Handler.CooperateTenantHandler;
using Tenant_App.Utilities.ExceptionUtility;

namespace Tenant_App.Services.Handler.ContractTypeHandler
{
    public class ContractTypeService : IContractType
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CooperateTenantService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailMessaging _emailManager;
        private readonly IConverter _converter;

        public ContractTypeService(AppDbContext context, ILogger<CooperateTenantService> logger, IConfiguration configuration,
            IEmailMessaging emailManager, IConverter converter)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _emailManager = emailManager;
            _converter = converter;
        }

        public async Task<string> CreateContractType(ContractTypeDto obj)
        {
            string status = "";
            try
            {
                var newContractType = new ContractType
                {
                    Name = obj.Name,
                };

                _context.ContractTypes.Add(newContractType);
                if (await _context.SaveChangesAsync() > 0)
                {
                    status = ResponseErrorMessageUtility.Succesful;
                    return status;
                }
                else
                {
                    status = ResponseErrorMessageUtility.RecordNotSaved;
                    return status;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating contract type: {ex.Message}");
                return "An error occurred while creating the contract type";
            }
        }

        public async Task<bool> DeleteContractType(Guid id)
        {
            try
            {
                var contractTypeToDelete = _context.ContractTypes.FirstOrDefault(x => x.Id == id);
                contractTypeToDelete.IsDeleted = true;
                if (await _context.SaveChangesAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting contract type: {ex.Message}");
                return false;
            }
        }

        public List<ContractTypeDto> GetAllContractType()
        {
            try
            {
                var contractTypes = _context.ContractTypes
                    .Where(ct => ct.IsDeleted != true)
                    .Select(ct => new ContractTypeDto
                    {
                        Id = ct.Id,
                        Name = ct.Name,
                    })
                    .ToList();

                return contractTypes;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving contract types: {ex.Message}");
                return new List<ContractTypeDto>();
            }
        }

        public async Task<ContractTypeDto> GetById(Guid id)
        {
            try
            {
                var contractType =  _context.ContractTypes
                    .Where(c => c.Id == id)
                    .Select(contract => new ContractTypeDto
                    {
                        Id= contract.Id,
                        Name = contract.Name,

                    }).FirstOrDefault();
                return contractType;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving contract type: {ex.Message}");
                return null;
            }
        }

        public async Task<string> UpdateContractType(ContractTypeDto obj, Guid id)
        {
            string status = "";
            try
            {
                var existingContractType = _context.ContractTypes.FirstOrDefault(x => x.Name == obj.Name);

                if (existingContractType != null)
                {
                    string msg = "ContractType " + obj.Name + " already exist";

                    status = string.Format(msg, obj.Name);
                    return status;
                }

                var model = _context.ContractTypes.FirstOrDefault(x => x.Id == obj.Id);
                model.Name = obj.Name;
                model.IsActive = true;
                model.ModifiedBy = obj.CreatedBy;
                model.LastModified = DateTime.Now;
                model.IsDeleted = false;
                if (await _context.SaveChangesAsync() > 0)
                {
                    status = ResponseErrorMessageUtility.UpdateRecord;
                    return status;
                }
                else
                {
                    status = ResponseErrorMessageUtility.RecordNotSaved;
                    return status;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating contract type: {ex.Message}");
                return "An error occurred while updating the contract type";
            }
        }
    }
}
