namespace GameAssetsStore.Services.Data.Interfaces;

using Microsoft.AspNetCore.Http;

public interface IObjectStoreService
{
    Task<bool> UploadAsync(IFormFile file, string assetId, string? fileName = null);
}
