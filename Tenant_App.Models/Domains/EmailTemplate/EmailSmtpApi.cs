using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Models.Domains.EmailTemplate
{
    public class EmailSmtpApiPost
    {
        public string senderName { get; set; }
        public string recieverName { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string subject { get; set; }
        public string projectCode { get; set; }
        public string messageBody { get; set; }
        public List<OtherEmails> otherEmails { get; set; }
        public bool sentNow { get; set; }
        public DateTime scheduleDate { get; set; }
    }

    public class OtherEmails
    {
        public string bbcRecieverEmail { get; set; }
        public string bbcRecieverName { get; set; }
        public string ccRecieverEmail { get; set; }
        public string ccRecieverName { get; set; }
    }
}
