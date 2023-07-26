namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.Area.ViewModels.Shop.Manage;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ArtStyleService : IArtStyleService
{
    private readonly IRepository<ArtStyle> artStyleRepository;

    public ArtStyleService(IRepository<ArtStyle> artStyleRepository)
    {
        this.artStyleRepository = artStyleRepository;
    }

    public async Task<List<ArtStyleFormModel>> GetArtStylesAsync()
    {
        return await this.artStyleRepository.GetAllAsNoTracking()
            .Select(a => new ArtStyleFormModel
            {
                Id = a.Id,
                Name = a.Name
            })
            .ToListAsync();
    }
}
