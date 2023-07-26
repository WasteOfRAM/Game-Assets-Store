namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.Area.ViewModels.Shop.Manage;

public interface IArtStyleService
{
    Task<List<ArtStyleFormModel>> GetArtStylesAsync();
}
