namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.ViewModels.Manage;

public interface IArtStyleService
{
    Task<List<ArtStyleFormModel>> GetArtStylesAsync();
}
