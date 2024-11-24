using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using Tenant_App.Models.Domains;

namespace Tenant_App.Models.DataObjects.PropertyDtos
{
    public class PropertyRegDto : BaseObjectDataIntegrity
    {
        [Required(ErrorMessage = "Property Name is required")]
        [DisplayName("Property Name")]
        public string PropertyName { get; set; }
        [Required(ErrorMessage = "Property Description is required")]
        [DisplayName("Property Description")]
        public string PropertyDesciption { get; set; }
        [Required(ErrorMessage = "Property Information is required")]
        [DisplayName("Property Information")]
        public string PropertyInformation { get; set; }
        [Required(ErrorMessage = "Property Address is required")]
        [DisplayName("Property Address")]
        public string PropertyAddress { get; set; }
        [Required(ErrorMessage = "Duration Allowed is required")]
        [DisplayName("Duration Allowed")]
        public string DurationAllowed { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage = "Property Image is required")]
        [DisplayName("Property Image")]
        public IFormFile PropertyImagePath { get; set; }
        public string PropertyImage { get; set; }
        [Required(ErrorMessage = "Room number is required")]
        [DisplayName("Room Number")]
        public string RoomNumber { get; set; }
        [Required(ErrorMessage = "Available Room is required")]
        [DisplayName("Available Room Image")]
        public int AvailableRoom { get; set; }
        public int RemainingRoom { get; set; }
        public string Size { get; set; }
        public string Dimension { get; set; }
    }
}
