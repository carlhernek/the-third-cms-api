using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
namespace the_third_cms_api.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> Logger;
        private readonly BlobServiceClient BlobServiceClient;
        public FileService(ILogger<FileService> logger, BlobServiceClient blobServiceClient)
        {
            this.Logger = logger;
            this.BlobServiceClient = blobServiceClient;
        }

        //private string GenerateFileName(string filename, int id, MimeContent mime)
        //{
        //    return DateTime.Now.ToUniversalTime().ToString(filename + "_yyyy-MM-dd_" + id + "_HHmmssfff");
        //}

        public async Task<Uri> UploadFileAsync(string blobContainerName, Stream content, string contentType, string fileName, Guid id)
        {

            this.Logger.LogInformation($"Uploading files: containerName: {blobContainerName} : {contentType} + : {fileName}:ID: {id}");
            var containerClient = BlobServiceClient.GetBlobContainerClient(blobContainerName);
            var blobClient = containerClient.GetBlobClient(id.ToString());
            await blobClient.UploadAsync(content, new BlobHttpHeaders { ContentType = contentType });
            return blobClient.Uri;
        }
        public async Task<bool> DeleteFIleAsync(string filename)
        {
            var cl = BlobServiceClient.GetBlobContainerClient("testc").GetBlobClient(filename);
            var r = await cl.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
            return r.Value;
        }
    }
}
