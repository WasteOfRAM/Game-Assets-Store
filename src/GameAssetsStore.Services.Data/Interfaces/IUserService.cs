namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.ViewModels.User;

public interface IUserService
{
    Task<PublicProfileViewModel?> GetUserProfileAsync(string username);
}
