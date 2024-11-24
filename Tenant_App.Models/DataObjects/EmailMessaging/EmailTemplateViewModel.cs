using System;
using System.Collections.Generic;
using System.Text;
using Tenant_App.Models.Domains;

namespace Tenant_App.Models.DataObjects.EmailMessaging
{
    public class EmailTemplateViewModel :BaseObjectDataIntegrity
    {
        public Guid EmailTemplateId { get; set; }
        public string Subject { get; set; }
        public String MailBody { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

    }
}
