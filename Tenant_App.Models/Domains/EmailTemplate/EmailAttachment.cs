using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tenant_App.Models.Domains.EmailTemplate
{
    public class EmailAttachment : BaseObject
    {
         public Guid EmailLogId { get; set; }
         public string FolderOnServer { get; set; }
         public string FileNameOnServer { get; set; }
         public string EmailFileName { get; set; }

        public virtual EmailLog EmailLog { get; set; }
    }
}
