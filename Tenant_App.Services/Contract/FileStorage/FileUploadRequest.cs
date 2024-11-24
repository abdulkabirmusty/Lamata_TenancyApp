namespace Tenant_App.Services.Contract.FileStorage
{
    public class FileUploadRequest
    {
        public string Name { get; set; } = default!;
        public string Extension { get; set; } = default!;
        public string Data { get; set; } = default!;
    }

    //public class FileUploadRequestValidator : CustomValidator<FileUploadRequest>
    //{
    //    public FileUploadRequestValidator(IStringLocalizer<FileUploadRequestValidator> T)
    //    {
    //        RuleFor(p => p.Name)
    //            .NotEmpty()
    //                .WithMessage(T["Image Name cannot be empty!"])
    //            .MaximumLength(150);

    //        RuleFor(p => p.Extension)
    //            .NotEmpty()
    //                .WithMessage(T["Image Extension cannot be empty!"])
    //            .MaximumLength(5);

    //        RuleFor(p => p.Data)
    //            .NotEmpty()
    //                .WithMessage(T["Image Data cannot be empty!"]);
    //    }

    //    public (string data, string extension) ExtractBase64Data(string base64WithFormat)
    //    {
    //        string[] parts = base64WithFormat.Split(',');
    //        if (parts.Length == 2)
    //        {
    //            string mimeType = parts[0].Split(':')[1].Split(';')[0];
    //            string extension = GetExtensionFromMimeType(mimeType);
    //            return (parts[1], extension);
    //        }
    //        return (base64WithFormat, null);
    //    }

    //    public string GetExtensionFromMimeType(string mimeType)
    //    {
    //        switch (mimeType)
    //        {
    //            case "image/jpeg":
    //                return ".jpg";
    //            case "image/png":
    //                return ".png";
    //            // Add more MIME types and corresponding extensions as needed
    //            default:
    //                return null; // Handle unknown or unsupported MIME types
    //        }
    //    }
    //}
}