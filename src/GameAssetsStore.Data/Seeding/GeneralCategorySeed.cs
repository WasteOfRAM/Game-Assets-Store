namespace GameAssetsStore.Data.Seeding;

using GameAssetsStore.Data.Models;

public static class GeneralCategorySeed
{
    public static GeneralCategory[] GenerateCategories()
    {
        ICollection<GeneralCategory> categories = new HashSet<GeneralCategory>();

        GeneralCategory category;

        category = new GeneralCategory
        {
            Id = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            Name = "3D"
        };

        categories.Add(category);

        category = new GeneralCategory
        {
            Id = new Guid("E70AF9FB-3FE7-430E-A959-2C201383E83A"),
            Name = "Low poly"
        };

        categories.Add(category);

        category = new GeneralCategory
        {
            Id = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            Name = "2D"
        };

        categories.Add(category);

        category = new GeneralCategory
        {
            Id = new Guid("1E746E77-4E0A-4C04-ABA2-1A347767AD3A"),
            Name = "Textures"
        };

        categories.Add(category);

        category = new GeneralCategory
        {
            Id = new Guid("C98B256B-DC33-4680-A53E-084C0111844B"),
            Name = "Audio"
        };

        categories.Add(category);

        category = new GeneralCategory
        {
            Id = new Guid("14B122D0-90BF-45AA-8B92-E02CD29784D3"),
            Name = "Addons"
        };

        categories.Add(category);

        category = new GeneralCategory
        {
            Id = new Guid("510AF335-4B59-49FE-8022-141F5CC410D4"),
            Name = "Scripts"
        };

        categories.Add(category);

        category = new GeneralCategory
        {
            Id = new Guid("A27BB29F-B235-40D4-BB11-EA4318AFD3C6"),
            Name = "Vfx"
        };

        categories.Add(category);

        return categories.ToArray();
    }
}
