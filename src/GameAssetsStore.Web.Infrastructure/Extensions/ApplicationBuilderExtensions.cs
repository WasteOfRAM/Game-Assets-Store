namespace GameAssetsStore.Web.Infrastructure.Extensions;

using Microsoft.Extensions.DependencyInjection;

using GameAssetsStore.Services.Data;
using GameAssetsStore.Services.Data.Interfaces;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Data.Repositories;

public static class ApplicationBuilderExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<IShopService, ShopService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IArtStyleService, ArtStyleService>();
        services.AddScoped<IStorageService, S3StorageService>();
        services.AddScoped<ICartService, CartService>();
        services.AddScoped<ITransactionService, TransactionService>();

        return services;
    }

    public static IServiceCollection AddApplicationRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserProfileRepository, UserProfileRepository>();

        return services;
    }
}
