using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Tenant_App.Models.Domains;

namespace Tenant_App.Models.Domains.EmailTemplate
{
    public class EmailLog : BaseObject
    {

        public EmailLog()
        {
            EmailAttachments = new HashSet<EmailAttachment>();
        }

        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string CC { get; set; }
        public string BCC { get; set; }

        [Required(ErrorMessage = "Email Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message Body is required")]
        public string MessageBody { get; set; }

        public bool HasAttachment { get; set; }
        public bool IsSent { get; set; }
        public int Retires { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? DateToSend { get; set; }
        public virtual ICollection<EmailAttachment> EmailAttachments { get; set; }
    }
}
