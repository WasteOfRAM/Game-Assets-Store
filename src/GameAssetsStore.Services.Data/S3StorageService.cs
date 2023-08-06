namespace GameAssetsStore.Services.Data;

using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Services.Models.Asset;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
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
        var objectKey = $"{assetId}/{encodedFilename}";

        using var transferUtility = new TransferUtility(this.S3Client);

        await transferUtility.UploadAsync(file.OpenReadStream(), container, objectKey);
    }

    public async Task<DownloadAssetServiceModel> DownloadAsync(string container, string fileName, string assetId)
    {
        MemoryStream memoryStream;

        var objectRequest = new GetObjectRequest
        {
            BucketName = container,
            Key = $"{assetId}/{fileName}"
        };

        using var response = await this.S3Client.GetObjectAsync(objectRequest);

        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            using (memoryStream = new MemoryStream())
            {
                await response.ResponseStream.CopyToAsync(memoryStream);
            }

            return new DownloadAssetServiceModel 
            {
                FileStream = memoryStream.ToArray(),
                ContentType = response.Headers.ContentType
            };
        }
        else
        {
            throw new FileNotFoundException("The file was not found");
        }
    }

    public async Task DeleteAsync(string container, string fileName, string assetId)
    {
        var deleteRequest = new DeleteObjectRequest
        {
            BucketName = container,
            Key = $"{assetId}/{fileName}"
        };

        await this.S3Client.DeleteObjectAsync(deleteRequest);
    }

    public async Task<IEnumerable<string>> GetAssetImagesKeysAsync(string assetId, string container)
    {
        var request = new ListObjectsV2Request
        {
            BucketName = container,
            Prefix = assetId.ToLower() + "/",
        };

        var response = await this.S3Client.ListObjectsV2Async(request);

        var keys = response.S3Objects.Select(o => o.Key.Split("/")[1]).ToList();

        return keys;
    }
}
