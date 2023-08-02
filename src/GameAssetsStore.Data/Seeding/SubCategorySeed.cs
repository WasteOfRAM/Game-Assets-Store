namespace GameAssetsStore.Data.Seeding;

using GameAssetsStore.Data.Models;

public static class SubCategorySeed
{
    public static SubCategory[] GenerateSubCategories()
    {
        ICollection<SubCategory> categories = new HashSet<SubCategory>();

        SubCategory category;

        category = new SubCategory
        {
            Id = new Guid("1359383E-3A4E-408D-91FB-AA9B9425DF6F"),
            Name = "Characters"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("FDEB520B-93DB-492B-A152-19A5A9C29227"),
            Name = "Props"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("D8AC59B9-C97A-47DB-A3DE-3C7ED15515D5"),
            Name = "Environment"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("0CB36015-FFD6-4836-A0F3-2F8BC803A75E"),
            Name = "Materials"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("2681E9D1-344B-4D58-8916-2C8732465D0A"),
            Name = "Background"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("ABF6B357-436F-43CC-8EB9-7B4CB7A333DD"),
            Name = "Tile set"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("EEB4556F-1B3E-4B25-81EF-8F2C1CC11498"),
            Name = "Pixel Art"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("C78774C6-65C5-4D77-AB68-D9B27AEF707D"),
            Name = "Sprite sheet"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("89132449-6F33-4A1A-A8A0-24A72E99FAB7"),
            Name = "UI"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("465DA332-D175-4EA7-9452-EDDC8D6FE7E5"),
            Name = "Tileable"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("D38B77D4-2BA2-404E-BC9C-EE5A55925176"),
            Name = "Non Tileable"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("2F53EE6B-277E-4B76-810D-15414FE7B32B"),
            Name = "Decal"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("4E42EBA0-BE74-4B1B-968D-9C104A417C10"),
            Name = "VFX 3D"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("A1AE6147-9ED9-4243-8C9C-90D9A2549536"),
            Name = "VFX 2D"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("CCB576A8-1774-4FB3-81F6-B1BA285DA1F3"),
            Name = "Music"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("F5668D1F-6250-4DA1-87D9-FE144189D1FD"),
            Name = "Ambient"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("8359654E-6E96-4254-999B-51B0AD1C9E1F"),
            Name = "Sfx"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("5DCDA147-B9E1-4881-ADC9-C9ED4837C8CF"),
            Name = "Unreal Engine"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("DB6A3733-625E-4AD2-BDF5-32337A91DF12"),
            Name = "Godot"
        };

        categories.Add(category);

        category = new SubCategory
        {
            Id = new Guid("A9203C28-F272-4C4C-92B8-0D75352A31CB"),
            Name = "Unity"
        };

        categories.Add(category);

        return categories.ToArray();
    }
}
