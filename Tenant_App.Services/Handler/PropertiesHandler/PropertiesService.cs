using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.PropertyDtos;
using Tenant_App.Services.Contract.PropertiesContract;
using Tenant_App.Services.Handler.PropertyHandler;

namespace Tenant_App.Services.Handler.PropertiesHandler
{
    public class PropertiesService : IProperties
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PropertiesService> _logger;


        public PropertiesService(AppDbContext context, ILogger<PropertiesService> logger)
        {
            _context = context;
            _logger = logger;

        }

        public List<PropertyDto> GetAllProperty()
        {
            try
            {
                var property = _context.Properties
                    .Where(ct => ct.IsDeleted != true)
                    .Select(p => new PropertyDto
                    {
                        Id = p.Id,
                        PropertyName = p.PropertyName,
                        PropertyAddress = p.PropertyAddress,
                        PropertyDesciption = p.PropertyDesciption,
                        PropertyImage = p.PropertyImagePath,
                        PropertyInformation = p.PropertyInformation,
                        AvailableRoom = p.AvailableRoom,
                        Amount = p.Amount,
                        DurationAllowed = p.DurationAllowed,
                        RemainingRoom = p.RemainingRoom,
                        Size = p.Size,
                        Dimension = p.Dimension
                    })
                    .ToList();

                return property;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving property: {ex.Message}");
                return new List<PropertyDto>();
            }
        }

        public async Task<PropertyRegDto> GetPropertyById(Guid id)
        {
            try
            {
                var property = _context.Properties
                    .Where(c => c.Id == id)
                    .Select(prop => new PropertyRegDto
                    {
                        Id = prop.Id,
                        PropertyName = prop.PropertyName,
                        PropertyAddress = prop.PropertyAddress,
                        PropertyDesciption = prop.PropertyDesciption,
                        //PropertyImage = prop.PropertyImagePath,
                        PropertyInformation = prop.PropertyInformation,
                        Amount = prop.Amount,
                        DurationAllowed = prop.DurationAllowed,
                    }).FirstOrDefault();

                return property;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving property: {ex.Message}");
                return null;
            }
        }
    }
}
