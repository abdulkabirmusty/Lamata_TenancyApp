using System;
using System.Collections.Generic;
using System.Text;
using UNDP.Models.Domains.EmailCredentials;

namespace UNDP.Services.Contract.EmailMessaging
{
    public interface IReadEmail
    {
       List<EmailContent> Read_Emails();
    }
}
