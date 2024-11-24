using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.ContractTypeDtos;
using Tenant_App.Models.DataObjects.PropertyDtos;
using Tenant_App.Models.Domains.ContractTypeDomain;
using Tenant_App.Models.Domains.PropertyDomain;
using Tenant_App.Services.Contract.EmailMessaging;
using Tenant_App.Services.Contract.PropertyContract;
using Tenant_App.Services.Handler.CooperateTenantHandler;
using Tenant_App.Utilities.ExceptionUtility;

namespace Tenant_App.Services.Handler.PropertyHandler
{
    public class PropertyService : IProperty
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PropertyService> _logger;
        

        public PropertyService(AppDbContext context, ILogger<PropertyService> logger)
        {
            _context = context;
            _logger = logger;
            
        }


        public async Task<string> CreateProperty(PropertyRegDto obj)
        {
            string status = "";
            try
            {
                var newProperty = new Property
                {
                    PropertyName = obj.PropertyName,
                    PropertyAddress = obj.PropertyAddress,
                    PropertyDesciption = obj.PropertyDesciption,
                    PropertyInformation = obj.PropertyInformation,
                    PropertyImagePath = UploadImageFile(obj.PropertyImagePath, obj.PropertyName),
                    DurationAllowed = obj.DurationAllowed,
                    RoomNumber = obj.RoomNumber,
                    AvailableRoom = obj.AvailableRoom,
                    RemainingRoom = obj.AvailableRoom,
                    Size = obj.Size,
                    Dimension = obj.Dimension,

                };

                _context.Properties.Add(newProperty);
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
                _logger.LogError($"Error creating property: {ex.Message}");
                return "An error occurred while creating the property";
            }
        }

        public string UploadImageFile(IFormFile file, string propertyName)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string name = $"{Path.GetFileName(file.FileName)}";
            string fileName = propertyName + name;
            string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string filePath = Path.Combine(uploadsFolder, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return $"uploads/{fileName}";
        }

        public async Task<bool> DeleteProperty(Guid id)
        {
            try
            {
                var property = _context.Properties.FirstOrDefault(x => x.Id == id);
                property.IsDeleted = true;
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
                _logger.LogError($"Error deleting property: {ex.Message}");
                return false;
            }
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
                        //Amount = p.Amount,
                        DurationAllowed = p.DurationAllowed,
                        RoomNumber = p.RoomNumber,
                        AvailableRoom = p.AvailableRoom,
                        Size = p.Size,
                        Dimension = p.Dimension,
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
                var property = await _context.Properties
                    .Where(c => c.Id == id)
                    .Select(prop => new PropertyRegDto
                    {
                        Id = prop.Id,
                        PropertyName = prop.PropertyName,
                        PropertyAddress = prop.PropertyAddress,
                        PropertyDesciption = prop.PropertyDesciption,
                        //PropertyImage = prop.PropertyImagePath,
                        PropertyInformation = prop.PropertyInformation,
                        //Amount = prop.Amount,
                        DurationAllowed = prop.DurationAllowed,
                        RoomNumber = prop.RoomNumber,
                        AvailableRoom = prop.AvailableRoom,
                        RemainingRoom = prop.RemainingRoom,
                        Size = prop.Size,
                        Dimension = prop.Dimension
                    }).FirstOrDefaultAsync();

                return property;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving property: {ex.Message}");
                return null;
            }
        }

        public async Task<string> UpdateProperty(PropertyRegDto obj, Guid id)
        {
            string status = "";
            try
            {
                //var existingProperty = _context.Properties.FirstOrDefault(x => x.PropertyName == obj.PropertyName);
                //if (existingProperty != null)
                //{
                //    string msg = "Property " + obj.PropertyName + " already exist";

                //    status = string.Format(msg, obj.PropertyName);
                //    return status;
                //}

                var model = _context.Properties.FirstOrDefault(x => x.Id == obj.Id);

                model.PropertyName = obj.PropertyName;
                model.PropertyDesciption = obj.PropertyDesciption;
                model.PropertyAddress = obj.PropertyAddress;
                model.PropertyInformation = obj.PropertyInformation;
                //model.PropertyImagePath = UploadImageFile(obj.PropertyImagePath, obj.PropertyName);
                //model.Amount = obj.Amount;
                model.DurationAllowed = obj.DurationAllowed;
                model.RoomNumber = obj.RoomNumber;
                model.AvailableRoom = obj.AvailableRoom;
                model.RemainingRoom = obj.RemainingRoom;
                model.Size = obj.Size;
                model.Dimension = obj.Dimension;
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
                _logger.LogError($"Error updating property: {ex.Message}");
                return "An error occurred while updating the property";
            }
        }

        public async Task<bool> UpdateStatus(Guid id)
        {
            try
            {
                var model = _context.Properties
                    .FirstOrDefault(x => x.Id == id);

                if (model.IsActive)
                {
                    model.IsActive = false;
                }
                else
                {
                    model.IsActive = true;
                }

                model.LastModified = DateTime.Now;

                if (_context.SaveChanges() > 0)
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
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
