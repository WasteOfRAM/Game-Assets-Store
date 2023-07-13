namespace GameAssetsStore.Services.Data.Interfaces;

using GameAssetsStore.Web.ViewModels.Settings;
using GameAssetsStore.Web.ViewModels.User;

public interface IUserService
{
    Task<PublicProfileViewModel?> GetUserProfileAsync(string username);

    Task<ProfileSettingsFormModel> GetUserPublicProfileAsync(string userId);

    Task UpdateUserPublicProfileAsync(ProfileSettingsFormModel model, string userId);
}
