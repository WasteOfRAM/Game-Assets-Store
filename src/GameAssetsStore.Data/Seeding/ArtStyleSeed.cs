namespace GameAssetsStore.Data.Seeding;

using GameAssetsStore.Data.Models;

public static class ArtStyleSeed
{
    public static ArtStyle[] GenerateArtStyles()
    {
        ICollection<ArtStyle> styles = new HashSet<ArtStyle>();

        ArtStyle artStyle;

        artStyle = new ArtStyle
        {
            Name = "Modern"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Name = "Medieval"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Name = "Futuristic"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Name = "Steampunk"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Name = "Sci-Fi"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Name = "Fantasy"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Name = "Cyberpunk"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Name = "Retro"
        };

        styles.Add(artStyle);

        return styles.ToArray();
    }
}
