﻿namespace GameAssetsStore.Services.Data;

using Microsoft.EntityFrameworkCore;
using Services.Data.Interfaces;
using System.Threading.Tasks;

using GameAssetsStore.Data.Models;
using GameAssetsStore.Data.Repositories.Interfaces;
using GameAssetsStore.Web.ViewModels.User;

public class UserService : IUserService
{
    private readonly IRepository<UserProfile> profileRepo;

    public UserService(IRepository<UserProfile> profileRepo)
    {
        this.profileRepo = profileRepo;
    }

    public Task<PublicProfileViewModel?> GetUserProfileAsync(string username)
    {
        return Task.FromResult(this.profileRepo.GetAll()
            .Where(up => up.User.UserName == username)
            .Include(up => up.SocialLinks)
            .AsNoTracking()
            .AsEnumerable()
            .Select(up => new PublicProfileViewModel
            {
                Id = up.Id,
                Username = username,
                About = up.About,
                PublicEmail = up.PublicEmail,
                Website = up.Website,
                SocialLinks = up.SocialLinks.ToDictionary(l => l.SocialType.ToString(), l => l.LinkUrl)
            }).FirstOrDefault());
    }
}
