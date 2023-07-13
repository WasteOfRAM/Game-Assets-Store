namespace GameAssetsStore.Web.ViewModels.User;

public class PublicProfileViewModel
{
    public PublicProfileViewModel()
    {
        this.SocialLinks = new Dictionary<string, string>();
    }

    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string? About { get; set; }

    public string? PublicEmail { get; set; }

    public string? Website { get; set; }

    public Dictionary<string, string> SocialLinks { get; set; }
}
