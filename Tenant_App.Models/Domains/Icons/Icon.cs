using System.ComponentModel.DataAnnotations.Schema;

namespace Tenant_App.Models.Domains.Icons
{
    public class Icon : BaseObject
    {
      
        public string IconName { get; set; }

        public string IconCode { get; set; }
    }
}
