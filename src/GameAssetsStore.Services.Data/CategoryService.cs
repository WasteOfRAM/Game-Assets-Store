namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels.Manage;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryService : ICategoryService
{
    private readonly IRepository<GeneralCategory> categoriesRepository;

    public CategoryService(IRepository<GeneralCategory> categoriesRepository)
    {
        this.categoriesRepository = categoriesRepository;
    }

    public async Task<List<AssetCategoryFormModel>> GetAllCategoriesWithSubCategoriesAsync()
    {
        return await this.categoriesRepository.GetAllAsNoTracking()
            .Include(c => c.SubCategories)
            .Select(c => new AssetCategoryFormModel
            {
                Id = c.Id,
                Name = c.Name,
                SubCategories = c.SubCategories
                    .Select(sc => new SubCategoryFormModel
                    {
                        Id = sc.Id,
                        Name = sc.Name
                    }).ToList()
            })
            .ToListAsync();
    }
}
