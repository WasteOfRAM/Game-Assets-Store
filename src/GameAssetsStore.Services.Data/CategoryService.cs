namespace GameAssetsStore.Services.Data;

using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Web.ViewModels.Manage;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryService : ICategoryService
{
    private readonly IGeneralCategoryRepository categoriesRepository;

    public CategoryService(IGeneralCategoryRepository categoriesRepository)
    {
        this.categoriesRepository = categoriesRepository;
    }

    public async Task<List<AssetCategoryFormModel>> GetAllCategoriesWithSubCategories()
    {
        var allCategories = await this.categoriesRepository.GetAllWithSubCategories();

        return allCategories
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
            .ToList();
    }
}
