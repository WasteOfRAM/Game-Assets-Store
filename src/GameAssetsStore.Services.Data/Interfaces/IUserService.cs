namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.ViewModels.User;

public interface IUserService
{
    Task<UserProfileViewModel?> GetUserProfileAsync(string username);
}
