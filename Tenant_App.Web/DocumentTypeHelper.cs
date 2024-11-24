using System;

namespace Tenant_App.Web
{
    public class DocumentTypeHelper
    {
        public static Guid GetDocumentTypeGuid(string documentType)
        {
            if (Guid.TryParse(documentType, out Guid result))
            {
                return result;
            }

            throw new ArgumentException("Invalid document type", nameof(documentType));
        }
    }
}

