namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels.Manage;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ArtStyleService : IArtStyleService
{
    private readonly IArtStyleRepository artStyleRepository;

    public ArtStyleService(IArtStyleRepository artStyleRepository)
    {
        this.artStyleRepository = artStyleRepository;
    }

    public async Task<List<ArtStyleFormModel>> GetArtStylesAsync()
    {
        var allArtStyles = await this.artStyleRepository.GetAllAsNoTracking();

        return allArtStyles
            .Select(a => new ArtStyleFormModel
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToList();
    }
}
