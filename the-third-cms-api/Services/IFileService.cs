using System;
using System.IO;
using System.Threading.Tasks;

namespace the_third_cms_api.Services
{
    public interface IFileService
    {
        Task<Uri> UploadFileAsync(string blobContainerName, Stream content, string contentType, string fileName, Guid id);
        Task<bool> DeleteFIleAsync(string filename);
    }
}
