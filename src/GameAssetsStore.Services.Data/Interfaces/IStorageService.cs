namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Services.Models.Asset;
using Microsoft.AspNetCore.Http;

public interface IStorageService
{
    Task UploadAsync(IFormFile file, string assetId, string container, string encodedFilename);

    Task<DownloadAssetServiceModel> DownloadAsync(string container, string fileName, string assetId);

    Task DeleteAsync(string container, string fileName, string assetId);

    Task<IEnumerable<string>> GetAssetImagesKeysAsync(string assetId, string container);
}
