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
            Id = new Guid("0263C1C2-DA3E-4496-9CDA-DCB89213A9D6"),
            Name = "Modern"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Id = new Guid("77BD0468-6C70-4314-936B-B9612604E257"),
            Name = "Medieval"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Id = new Guid("B8EC1523-E249-45CC-8C48-EF78915A5E52"),
            Name = "Futuristic"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Id = new Guid("D5BC94DD-A06C-4744-BE19-4206A84AB96C"),
            Name = "Steampunk"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Id = new Guid("E7592028-354C-46CE-ADEC-B41525CCF712"),
            Name = "Sci-Fi"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Id = new Guid("9239D5BA-E831-4B1D-9F4A-7016F096D2AD"),
            Name = "Fantasy"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Id = new Guid("D56F1F8F-826B-4889-A1E7-AB10AB63E975"),
            Name = "Cyberpunk"
        };

        styles.Add(artStyle);

        artStyle = new ArtStyle
        {
            Id = new Guid("BB41CAD1-38DC-4895-BCB4-781D25821BED"),
            Name = "Retro"
        };

        styles.Add(artStyle);

        return styles.ToArray();
    }
}
