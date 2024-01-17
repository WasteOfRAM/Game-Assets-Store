namespace GameAssetsStore.Data.Repositories;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;

public class ArtStyleRepository : EfRepositoryBase<ArtStyle>, IArtStyleRepository
{
    public ArtStyleRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
