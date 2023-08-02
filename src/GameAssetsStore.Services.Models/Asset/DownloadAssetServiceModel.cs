namespace GameAssetsStore.Services.Models.Asset;

public class DownloadAssetServiceModel
{
    public byte[] FileStream { get; set; } = null!;

    public string? FileName { get; set; }

    public string ContentType { get; set; } = null!;
}
