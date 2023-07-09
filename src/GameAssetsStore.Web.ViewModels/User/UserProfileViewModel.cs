namespace GameAssetsStore.Web.ViewModels.User;

public class UserProfileViewModel
{
    public UserProfileViewModel()
    {
        this.Links = new Dictionary<string, string>();
    }

    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string? About { get; set; }

    public Dictionary<string, string> Links { get; set; }
}
