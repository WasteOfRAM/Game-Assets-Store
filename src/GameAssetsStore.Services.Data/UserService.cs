namespace GameAssetsStore.Services.Data;

using System.Threading.Tasks;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Web.ViewModels.User;
using Services.Data.Interfaces;

public class UserService : IUserService
{
    private readonly IRepository<UserProfile> profileRepo;

    public UserService(IRepository<UserProfile> profileRepo)
    {
        this.profileRepo = profileRepo;
    }

    public Task<UserProfileViewModel> GetUserProfileAsync(string username)
    {
        throw new NotImplementedException();
    }
}
