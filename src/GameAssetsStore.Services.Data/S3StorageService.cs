namespace GameAssetsStore.Services.Data;

using Amazon.S3;
using Amazon.S3.Transfer;
using GameAssetsStore.Services.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class S3StorageService : IStorageService
{
    private readonly IAmazonS3 S3Client;

    public S3StorageService(IAmazonS3 S3Client)
    {
        this.S3Client = S3Client;
    }

    public async Task UploadAsync(IFormFile file, string assetId, string container, string encodedFilename)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentNullException(nameof(file), "File is empty");
        }

        var objectKey = $"{assetId}/{encodedFilename}";

        using var transferUtility = new TransferUtility(this.S3Client);

        await transferUtility.UploadAsync(file.OpenReadStream(), container, objectKey);
    }
}
