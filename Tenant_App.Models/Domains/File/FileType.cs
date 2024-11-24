using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tenant_App.Models.Domains.File
{
    public enum FileType
    {
        [Description(".jpg,.png,.jpeg,.doc,.docx,.pdf")]
        Image,
        [Description(".pdf")]
        pdf,
        doc,
        docx,
        [Description(".mp4")]
        video,
    }
}
