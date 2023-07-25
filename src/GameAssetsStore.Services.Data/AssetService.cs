namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Area.ViewModels.Shop.Manage;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

public class AssetService : IAssetService
{
    private readonly IRepository<Asset> assetRepository;
    private readonly IRepository<Shop> shopRepository;
    private readonly IRepository<GeneralCategory> categoriesRepository;
    private readonly IObjectStoreService objectStoreService;

    public AssetService(IRepository<Asset> assetRepository,
        IRepository<Shop> shopRepository,
        IObjectStoreService objectStoreService,
        IRepository<GeneralCategory> categoriesRepository)
    {
        this.assetRepository = assetRepository;
        this.shopRepository = shopRepository;
        this.objectStoreService = objectStoreService;
        this.categoriesRepository = categoriesRepository;
    }

    public async Task<bool> CreateAssetAsync(CreateAssetFormModel model, string shopId)
    {
        var assetEntity = new Asset()
        {
            ShopId = Guid.Parse(shopId),
            AssetName = WebUtility.HtmlEncode(model.AssetTitle),
            FileName = WebUtility.HtmlEncode(model.AssetFile.FileName),
            Description = WebUtility.HtmlEncode(model.Description),
            Version = WebUtility.HtmlEncode(model.Version),
            Price = model.Price
        };

        await this.assetRepository.AddAsync(assetEntity);
        var shop = await this.shopRepository.GetAll().FirstAsync(s => s.Id == assetEntity.ShopId);

        

        bool isUploadSuccessful = await this.objectStoreService.UploadAsync(model.AssetFile, assetEntity.Id.ToString(), "asset");

        if (!isUploadSuccessful)
        {
            return false;
        }

        await this.assetRepository.SaveChangesAsync();

        await this.objectStoreService.UploadAsync(model.CoverImage, assetEntity.Id.ToString(), "cover");

        for (int i = 0; i < model.Images.Count(); i++)
        {
            await this.objectStoreService.UploadAsync(model.Images[i], assetEntity.Id.ToString(), $"media{i + 1}");
        }

        return true;
    }
}
