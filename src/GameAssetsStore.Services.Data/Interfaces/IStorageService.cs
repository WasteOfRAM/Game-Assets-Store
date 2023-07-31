namespace GameAssetsStore.Services.Data.Interfaces;

using Microsoft.AspNetCore.Http;

public interface IStorageService
{
    Task UploadAsync(IFormFile file, string assetId, string container, string encodedFilename);
}
