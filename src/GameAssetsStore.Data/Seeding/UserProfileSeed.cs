namespace GameAssetsStore.Data.Seeding;

using GameAssetsStore.Data.Models;

public static class UserProfileSeed
{
    public static UserProfile[] GenerateUserProfiles()
    {
        ICollection<UserProfile> userProfiles = new HashSet<UserProfile>();

        UserProfile userProfile;

        userProfile = new UserProfile
        {
            Id = new Guid("A82ABED6-405E-4438-A780-181794006611"),
            UserId = new Guid("37216E26-1916-41FB-B264-5D06F7872225")
        };

        userProfiles.Add(userProfile);

        userProfile = new UserProfile
        {
            Id = new Guid("2B23B498-7AE0-40DB-8200-A0F360635BDB"),
            UserId = new Guid("AE3730FD-295E-4778-ABC4-8A636E9F645E")
        };

        userProfiles.Add(userProfile);

        userProfile = new UserProfile
        {
            Id = new Guid("915DACDC-65F6-412E-AF5D-AC191BF29487"),
            UserId = new Guid("883E940E-E696-495C-A527-F4B497DE1995")
        };

        userProfiles.Add(userProfile);

        return userProfiles.ToArray();
    }
}
