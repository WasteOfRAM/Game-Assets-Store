namespace GameAssetsStore.Data.Seeding;

using GameAssetsStore.Data.Models;

public static class AssetSeed
{
    public static Asset[] GenerateAssets()
    {
        ICollection<Asset> assets = new HashSet<Asset>();

        Asset asset;

        asset = new Asset
        {
            Id = new Guid("6A593E06-B76D-4FC8-97A9-1400C907F378"),
            ShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            AssetName = "Stick man Animation Walk",
            Description = "Stick man animation series. Walk.\r\n\r\nSprite sheet 5 frames.",
            Price = 1.50m,
            Version = "A-3",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 21, 17, 41),
            IsPublic = false,
            FileName = "spritesheet.zip",
            ArtStyleId = new Guid("9239D5BA-E831-4B1D-9F4A-7016F096D2AD")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("33693985-9F7E-464F-9DEE-2005A19A1865"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Torus",
            Description = "Another shape\r\n\r\n\r\n\r\n\r\n\r\n",
            Price = null,
            Version = "Hm",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 39, 48),
            IsPublic = false,
            FileName = "torus.zip",
            ArtStyleId = new Guid("E7592028-354C-46CE-ADEC-B41525CCF712")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("C017A10C-80F3-4184-AC8B-2B912C15D568"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Cylinder",
            Description = null,
            Price = 2.00m,
            Version = "A",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 30, 1),
            IsPublic = false,
            FileName = "Cylinder.zip",
            ArtStyleId = new Guid("B8EC1523-E249-45CC-8C48-EF78915A5E52")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("755DCF8A-BE70-4351-8CD3-4EBD2765E520"),
            ShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            AssetName = "Monekey",
            Description = "Yep",
            Price = null,
            Version = "z23",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 51, 0),
            IsPublic = false,
            FileName = "Suzanne.zip",
            ArtStyleId = new Guid("9239D5BA-E831-4B1D-9F4A-7016F096D2AD")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("9E7A3E53-AE65-4908-AA4C-9291DDA70717"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Sphere",
            Description = "A sphere.\r\nIt can be used as a ball as well.\r\n\r\nMarble.\r\nBasically anything round sphere like that you need.\r\n\r\nI&#39;m putting it in a wrong category to test things. ",
            Price = 345.00m,
            Version = "A-3",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 37, 28),
            IsPublic = false,
            FileName = "sphere.zip",
            ArtStyleId = new Guid("E7592028-354C-46CE-ADEC-B41525CCF712")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("97501E8C-CC13-4123-B79D-B4EF776919AA"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Gear",
            Description = "Cogwheel with a hole.",
            Price = 33.33m,
            Version = "43.5V",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 31, 57),
            IsPublic = false,
            FileName = "gear.zip",
            ArtStyleId = new Guid("D5BC94DD-A06C-4744-BE19-4206A84AB96C")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("F3813F3F-E34A-49A6-A439-BC5A2273184C"),
            ShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            AssetName = "A totally different bolt",
            Description = "Will do new ones if I got time left so probably not.",
            Price = 44.00m,
            Version = "45g",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 49, 42),
            IsPublic = false,
            FileName = "bolt.zip",
            ArtStyleId = new Guid("B8EC1523-E249-45CC-8C48-EF78915A5E52")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("588F0697-EA69-42B5-A465-C49B2D381863"),
            ShopId = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            AssetName = "Stick man Animation Idle",
            Description = "Stick man animation series. Idle.\r\n\r\nSprite sheet 5 frames.",
            Price = 1.00m,
            Version = "new",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 21, 14, 49),
            IsPublic = false,
            FileName = "spritesheet.zip",
            ArtStyleId = new Guid("D56F1F8F-826B-4889-A1E7-AB10AB63E975")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("B02D32FA-4AE8-4724-9586-C56683FF9DCD"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Fiber Texture",
            Description = "A texture that is actually from a real thing I did.\r\nhttps://www.youtube.com/watch?v=GzbGfSNuxSc",
            Price = 17.50m,
            Version = "new",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 44, 16),
            IsPublic = false,
            FileName = "fiber_set.zip",
            ArtStyleId = new Guid("BB41CAD1-38DC-4895-BCB4-781D25821BED")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("C7BC601F-C4A1-4569-8B6A-CDC57714E40D"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Suzanne From Blender",
            Description = "A named monkey head.",
            Price = null,
            Version = "Suzanne",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 46, 25),
            IsPublic = false,
            FileName = "Suzanne.zip",
            ArtStyleId = new Guid("77BD0468-6C70-4314-936B-B9612604E257")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("7EFBF3D9-4206-4B7B-B659-F0072348D9F0"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Cube",
            Description = "A cube. It has 6 sides! ",
            Price = null,
            Version = "2z",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 28, 25),
            IsPublic = false,
            FileName = "cube.zip",
            ArtStyleId = new Guid("BB41CAD1-38DC-4895-BCB4-781D25821BED")
        };

        assets.Add(asset);

        asset = new Asset
        {
            Id = new Guid("3A815A72-FC65-4A95-BCD1-F22583602817"),
            ShopId = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            AssetName = "Bolt",
            Description = "A nice bolt.",
            Price = 25.00m,
            Version = "0.2",
            SalesCount = 0,
            CreatedOn = new DateTime(2023, 08, 03, 20, 26, 48),
            IsPublic = false,
            FileName = "bolt.zip",
            ArtStyleId = new Guid("0263C1C2-DA3E-4496-9CDA-DCB89213A9D6")
        };

        assets.Add(asset);

        return assets.ToArray();
    }

    public static object[] GenerateAssetsCategories()
    {
        ICollection<object> assetsCategories = new HashSet<object>();

        object ac;

        ac = new
        {
            CategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            AssetId = new Guid("6A593E06-B76D-4FC8-97A9-1400C907F378")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("C98B256B-DC33-4680-A53E-084C0111844B"),
            AssetId = new Guid("33693985-9F7E-464F-9DEE-2005A19A1865")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("A27BB29F-B235-40D4-BB11-EA4318AFD3C6"),
            AssetId = new Guid("33693985-9F7E-464F-9DEE-2005A19A1865")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            AssetId = new Guid("C017A10C-80F3-4184-AC8B-2B912C15D568")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            AssetId = new Guid("755DCF8A-BE70-4351-8CD3-4EBD2765E520")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("14B122D0-90BF-45AA-8B92-E02CD29784D3"),
            AssetId = new Guid("9E7A3E53-AE65-4908-AA4C-9291DDA70717")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("E70AF9FB-3FE7-430E-A959-2C201383E83A"),
            AssetId = new Guid("97501E8C-CC13-4123-B79D-B4EF776919AA")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            AssetId = new Guid("97501E8C-CC13-4123-B79D-B4EF776919AA")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("510AF335-4B59-49FE-8022-141F5CC410D4"),
            AssetId = new Guid("F3813F3F-E34A-49A6-A439-BC5A2273184C")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("14B122D0-90BF-45AA-8B92-E02CD29784D3"),
            AssetId = new Guid("F3813F3F-E34A-49A6-A439-BC5A2273184C")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            AssetId = new Guid("588F0697-EA69-42B5-A465-C49B2D381863")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("1E746E77-4E0A-4C04-ABA2-1A347767AD3A"),
            AssetId = new Guid("B02D32FA-4AE8-4724-9586-C56683FF9DCD")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            AssetId = new Guid("C7BC601F-C4A1-4569-8B6A-CDC57714E40D")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("E70AF9FB-3FE7-430E-A959-2C201383E83A"),
            AssetId = new Guid("7EFBF3D9-4206-4B7B-B659-F0072348D9F0")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            AssetId = new Guid("7EFBF3D9-4206-4B7B-B659-F0072348D9F0")
        };

        assetsCategories.Add(ac);

        ac = new
        {
            CategoryId = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            AssetId = new Guid("3A815A72-FC65-4A95-BCD1-F22583602817")
        };

        assetsCategories.Add(ac);

        return assetsCategories.ToArray();
    }

    public static object[] GenerateAssetsSubCategories()
    {
        ICollection<object> assetsSubCategories = new HashSet<object>();

        object asc;

        asc = new
        {
            AssetId = new Guid("F3813F3F-E34A-49A6-A439-BC5A2273184C"),
            SubCategoryId = new Guid("A9203C28-F272-4C4C-92B8-0D75352A31CB")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("C017A10C-80F3-4184-AC8B-2B912C15D568"),
            SubCategoryId = new Guid("FDEB520B-93DB-492B-A152-19A5A9C29227")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("97501E8C-CC13-4123-B79D-B4EF776919AA"),
            SubCategoryId = new Guid("FDEB520B-93DB-492B-A152-19A5A9C29227")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("C7BC601F-C4A1-4569-8B6A-CDC57714E40D"),
            SubCategoryId = new Guid("FDEB520B-93DB-492B-A152-19A5A9C29227")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("7EFBF3D9-4206-4B7B-B659-F0072348D9F0"),
            SubCategoryId = new Guid("FDEB520B-93DB-492B-A152-19A5A9C29227")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("3A815A72-FC65-4A95-BCD1-F22583602817"),
            SubCategoryId = new Guid("FDEB520B-93DB-492B-A152-19A5A9C29227")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("755DCF8A-BE70-4351-8CD3-4EBD2765E520"),
            SubCategoryId = new Guid("89132449-6F33-4A1A-A8A0-24A72E99FAB7")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("755DCF8A-BE70-4351-8CD3-4EBD2765E520"),
            SubCategoryId = new Guid("2681E9D1-344B-4D58-8916-2C8732465D0A")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("F3813F3F-E34A-49A6-A439-BC5A2273184C"),
            SubCategoryId = new Guid("DB6A3733-625E-4AD2-BDF5-32337A91DF12")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("97501E8C-CC13-4123-B79D-B4EF776919AA"),
            SubCategoryId = new Guid("D8AC59B9-C97A-47DB-A3DE-3C7ED15515D5")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("7EFBF3D9-4206-4B7B-B659-F0072348D9F0"),
            SubCategoryId = new Guid("D8AC59B9-C97A-47DB-A3DE-3C7ED15515D5")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("33693985-9F7E-464F-9DEE-2005A19A1865"),
            SubCategoryId = new Guid("8359654E-6E96-4254-999B-51B0AD1C9E1F")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("33693985-9F7E-464F-9DEE-2005A19A1865"),
            SubCategoryId = new Guid("A1AE6147-9ED9-4243-8C9C-90D9A2549536")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("33693985-9F7E-464F-9DEE-2005A19A1865"),
            SubCategoryId = new Guid("4E42EBA0-BE74-4B1B-968D-9C104A417C10")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("6A593E06-B76D-4FC8-97A9-1400C907F378"),
            SubCategoryId = new Guid("1359383E-3A4E-408D-91FB-AA9B9425DF6F")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("755DCF8A-BE70-4351-8CD3-4EBD2765E520"),
            SubCategoryId = new Guid("1359383E-3A4E-408D-91FB-AA9B9425DF6F")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("C7BC601F-C4A1-4569-8B6A-CDC57714E40D"),
            SubCategoryId = new Guid("1359383E-3A4E-408D-91FB-AA9B9425DF6F")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("9E7A3E53-AE65-4908-AA4C-9291DDA70717"),
            SubCategoryId = new Guid("5DCDA147-B9E1-4881-ADC9-C9ED4837C8CF")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("6A593E06-B76D-4FC8-97A9-1400C907F378"),
            SubCategoryId = new Guid("C78774C6-65C5-4D77-AB68-D9B27AEF707D")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("588F0697-EA69-42B5-A465-C49B2D381863"),
            SubCategoryId = new Guid("C78774C6-65C5-4D77-AB68-D9B27AEF707D")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("B02D32FA-4AE8-4724-9586-C56683FF9DCD"),
            SubCategoryId = new Guid("D38B77D4-2BA2-404E-BC9C-EE5A55925176")
        };

        assetsSubCategories.Add(asc);

        asc = new
        {
            AssetId = new Guid("33693985-9F7E-464F-9DEE-2005A19A1865"),
            SubCategoryId = new Guid("F5668D1F-6250-4DA1-87D9-FE144189D1FD")
        };

        assetsSubCategories.Add(asc);

        return assetsSubCategories.ToArray();
    }
}
