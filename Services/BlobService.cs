using Azure.Storage.Blobs;

namespace EmailTemplateApp.Services
{
    public class BlobService
    {
        private BlobServiceClient _blobServiceClient;

        public BlobService(IConfiguration configuration)
        {
            _blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("AzureStorage"));
        }

        public async Task UploadFileAsync(string blobName, Stream content)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("emailtemplates");
            await containerClient.UploadBlobAsync(blobName, content);
        }

    }

}
