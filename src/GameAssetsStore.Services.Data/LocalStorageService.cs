namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Services.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

public class LocalStorageService : IObjectStoreService
{
    private readonly IConfiguration configuration;

    public LocalStorageService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<bool> UploadAsync(IFormFile file, string assetId, string? fileName = null)
    {
        if (file == null || file.Length == 0)
        {
            return false;
        }

        var assetLocalStorage = Path.Combine(this.configuration.GetValue<string>("StoragePath:LocalStorage"), assetId);

        if (!Directory.Exists(assetLocalStorage))
        {
            Directory.CreateDirectory(assetLocalStorage);
        }

        var storageFileName = fileName != null ? fileName + Path.GetExtension(file.FileName) : file.FileName;

        var filePath = Path.Combine(assetLocalStorage, storageFileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return true;
    }
}
