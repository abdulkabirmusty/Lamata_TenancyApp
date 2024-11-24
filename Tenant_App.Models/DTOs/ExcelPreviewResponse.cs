using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.DTOs
{
    public class ExcelPreviewResponse <T> where T : class
    {
        public ICollection<T>? Duplicates { get; set; } 
        public ICollection<T>? RecordsWithNullColumns { get; set; } 
        public ICollection<T>? UploadableRecord { get; set; }
        public ExcelPreviewResponse()
        {
            Duplicates = new List<T>();
            RecordsWithNullColumns = new List<T>();
            UploadableRecord = new List<T>();
        }
    }
    
    //public class EnrollmentResponse
    //{
    //    public string Response { get; set; }
    //    public List<NominalRoll> FaultyRecords { get; set; } = new List<NominalRoll>();
    //}
}
