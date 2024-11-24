using System;
using System.Collections.Generic;
using System.Text;

namespace Tenant_App.Utilities.DocumentHandler
{
    public class DocumentTypesHelper
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
