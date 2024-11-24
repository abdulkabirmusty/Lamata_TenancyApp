using Tenant_App.Models.Domains.File;
using System.Threading;
using System.Threading.Tasks;

namespace Tenant_App.Services.Contract.FileStorage
{
    public interface IFileStorageService
    {
        public Task<string> UploadAsync<T>(FileUploadRequest? request, FileType supportedFileType, CancellationToken cancellationToken = default)
        where T : class;

        public void Remove(string path);
    }
}