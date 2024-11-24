using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenant_App.Models.Data;
using Tenant_App.Models.DataObjects.DamageDtos;
using Tenant_App.Models.DataObjects.PropertyDtos;
using Tenant_App.Models.Domains.DamagesDomain;
using Tenant_App.Services.Contract.DamagesContract;
using Tenant_App.Services.Handler.PropertyHandler;
using Tenant_App.Utilities.ExceptionUtility;

namespace Tenant_App.Services.Handler.DamagesHandler
{
    public class DamageService : IDamage
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DamageService> _logger;


        public DamageService(AppDbContext context, ILogger<DamageService> logger)
        {
            _context = context;
            _logger = logger;

        }

        public async Task<string> CreateDamageReport(DamageDto obj)
        {
            string status = "";
            try
            {
                var newDamage = new Damage
                {
                    FullName = obj.FullName,
                    UserId = obj.UserId,
                    PropertyId = obj.PropertyId,
                    PropertyName = obj.PropertyName,
                    Description = obj.Description,
                    DamageImagePath = UploadImageFile(obj.DamageImagePath, obj.FullName),
                    DamageType = obj.DamageType,
                    ReportDate = obj.ReportDate,
                    status = obj.status,
                    Priority = obj.Priority

                };

                _context.Damages.Add(newDamage);
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
                _logger.LogError($"Error creating damage report: {ex.Message}");
                return "An error occurred while creating the damage report";
            }
        }

        public async Task<bool> DeleteDamage(Guid id)
        {
            try
            {
                var damage = _context.Damages.FirstOrDefault(x => x.Id == id);
                damage.IsDeleted = true;
                damage.IsActive = false; ;
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
                _logger.LogError($"Error deleting damage report: {ex.Message}");
                return false;
            }
        }

        public List<FetchDamageDto> GetAllDamages(string userId)
        {
            try
            {
                var damages = _context.Damages
                    .Where(ct => ct.IsDeleted != true && ct.UserId == userId)
                    .Select(p => new FetchDamageDto
                    {
                        Id = p.Id,
                        FullName = p.FullName,
                        UserId = p.UserId,
                        PropertyId = p.PropertyId,
                        PropertyName = p.PropertyName,
                        Description = p.Description,
                        DamageImagePath = p.DamageImagePath,
                        DamageType = p.DamageType,
                        ReportDate = p.ReportDate,
                        status = p.status,
                        Priority = p.Priority,
                    })
                    .ToList();

                return damages;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving damages report: {ex.Message}");
                return new List<FetchDamageDto>();
            }
        }

        public List<FetchDamageDto> GetAllDamages()
        {
            try
            {
                var damages = _context.Damages
                    .Where(ct => ct.IsDeleted != true)
                    .Select(p => new FetchDamageDto
                    {
                        Id = p.Id,
                        FullName = p.FullName,
                        UserId = p.UserId,
                        PropertyId = p.PropertyId,
                        PropertyName = p.PropertyName,
                        Description = p.Description,
                        DamageImagePath = p.DamageImagePath,
                        DamageType = p.DamageType,
                        ReportDate = p.ReportDate,
                        status = p.status,
                        Priority = p.Priority,
                    })
                    .ToList();

                return damages;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving damages report: {ex.Message}");
                return new List<FetchDamageDto>();
            }
        }

        public async Task<FetchDamageDto> GetDamagesById(Guid id)
        {
            try
            {
                var damage = await _context.Damages
                    .Where(d => d.Id == id && d.IsDeleted != true)
                    .Select(p => new FetchDamageDto
                    {
                        Id = p.Id,
                        FullName = p.FullName,
                        UserId = p.UserId,
                        PropertyName = p.PropertyName,
                        Description = p.Description,
                        DamageImagePath = p.DamageImagePath,
                        DamageType = p.DamageType,
                        ReportDate = p.ReportDate,
                        status = p.status,
                        Priority = p.Priority,
                        AdminComment = p.AdminComment,
                    })
                    .FirstOrDefaultAsync();

                return damage;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error retrieving damages report: {ex.Message}");
                return null;
            }
        }

        public async Task<string> UpdateDamage(DamageDto obj, Guid id)
        {
            string status = "";
            try
            {
                var model = _context.Damages.FirstOrDefault(x => x.Id == obj.Id);
                                
                model.FullName = obj.FullName;
                model.Description = obj.Description;
                model.DamageType = obj.DamageType;
                model.ReportDate = obj.ReportDate;
                model.status = obj.status;
                model.Priority = obj.Priority;
                model.LastModified = DateTime.Now;

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
                _logger.LogError($"Error updating damages report: {ex.Message}");
                return "An error occurred while updating the damages report";
            }
        }

        public async Task<string> UpdateAdminComment(DamageDto obj, Guid id)
        {
            string status = "";
            try
            {
                var model = _context.Damages.FirstOrDefault(x => x.Id == obj.Id);

                model.AdminComment = obj.AdminComment;
                model.status = obj.status;
                model.LastModified = DateTime.Now;

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
                _logger.LogError($"Error updating damages report: {ex.Message}");
                return "An error occurred while updating the damages report";
            }
        }

        public string UploadImageFile(IFormFile file, string fullName)
        {
            string fileExtension = Path.GetExtension(file.FileName);
            string name = $"{Path.GetFileName(file.FileName)}";
            string fileName = fullName + name;
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
    }
}
