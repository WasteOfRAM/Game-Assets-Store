namespace GameAssetsStore.Data.Seeding;

public static class CategoriesSubCategoriesSeed
{
    public static object[] GenerateCategoriesSubCategories()
    {
        ICollection<object> categoriesSubCategories = new HashSet<object>();

        object categorySubCategory;

        // Seeding 3D general category
        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            SubCategoryId = new Guid("1359383E-3A4E-408D-91FB-AA9B9425DF6F")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            SubCategoryId = new Guid("FDEB520B-93DB-492B-A152-19A5A9C29227")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            SubCategoryId = new Guid("D8AC59B9-C97A-47DB-A3DE-3C7ED15515D5")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("59A1562A-6E96-4D82-B025-A28CB59C7E0C"),
            SubCategoryId = new Guid("0CB36015-FFD6-4836-A0F3-2F8BC803A75E")
        };

        categoriesSubCategories.Add(categorySubCategory);

        // Seeding low poly 3D general category

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("E70AF9FB-3FE7-430E-A959-2C201383E83A"),
            SubCategoryId = new Guid("1359383E-3A4E-408D-91FB-AA9B9425DF6F")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("E70AF9FB-3FE7-430E-A959-2C201383E83A"),
            SubCategoryId = new Guid("FDEB520B-93DB-492B-A152-19A5A9C29227")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("E70AF9FB-3FE7-430E-A959-2C201383E83A"),
            SubCategoryId = new Guid("D8AC59B9-C97A-47DB-A3DE-3C7ED15515D5")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("E70AF9FB-3FE7-430E-A959-2C201383E83A"),
            SubCategoryId = new Guid("0CB36015-FFD6-4836-A0F3-2F8BC803A75E")
        };

        categoriesSubCategories.Add(categorySubCategory);

        // Seeding 2D general category

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            SubCategoryId = new Guid("2681E9D1-344B-4D58-8916-2C8732465D0A")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            SubCategoryId = new Guid("FDEB520B-93DB-492B-A152-19A5A9C29227")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            SubCategoryId = new Guid("1359383E-3A4E-408D-91FB-AA9B9425DF6F")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            SubCategoryId = new Guid("ABF6B357-436F-43CC-8EB9-7B4CB7A333DD")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            SubCategoryId = new Guid("EEB4556F-1B3E-4B25-81EF-8F2C1CC11498")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            SubCategoryId = new Guid("C78774C6-65C5-4D77-AB68-D9B27AEF707D")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("5ED5F1C8-98C6-48E0-B479-51A81D3036D9"),
            SubCategoryId = new Guid("89132449-6F33-4A1A-A8A0-24A72E99FAB7")
        };

        categoriesSubCategories.Add(categorySubCategory);

        // Seeding Textures category

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("1E746E77-4E0A-4C04-ABA2-1A347767AD3A"),
            SubCategoryId = new Guid("465DA332-D175-4EA7-9452-EDDC8D6FE7E5")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("1E746E77-4E0A-4C04-ABA2-1A347767AD3A"),
            SubCategoryId = new Guid("D38B77D4-2BA2-404E-BC9C-EE5A55925176")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("1E746E77-4E0A-4C04-ABA2-1A347767AD3A"),
            SubCategoryId = new Guid("2F53EE6B-277E-4B76-810D-15414FE7B32B")
        };

        categoriesSubCategories.Add(categorySubCategory);

        // Seeding VFX category

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("A27BB29F-B235-40D4-BB11-EA4318AFD3C6"),
            SubCategoryId = new Guid("4E42EBA0-BE74-4B1B-968D-9C104A417C10")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("A27BB29F-B235-40D4-BB11-EA4318AFD3C6"),
            SubCategoryId = new Guid("A1AE6147-9ED9-4243-8C9C-90D9A2549536")
        };

        categoriesSubCategories.Add(categorySubCategory);

        // Seeding Audio category

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("C98B256B-DC33-4680-A53E-084C0111844B"),
            SubCategoryId = new Guid("CCB576A8-1774-4FB3-81F6-B1BA285DA1F3")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("C98B256B-DC33-4680-A53E-084C0111844B"),
            SubCategoryId = new Guid("F5668D1F-6250-4DA1-87D9-FE144189D1FD")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("C98B256B-DC33-4680-A53E-084C0111844B"),
            SubCategoryId = new Guid("8359654E-6E96-4254-999B-51B0AD1C9E1F")
        };

        categoriesSubCategories.Add(categorySubCategory);

        // Seeding Addons category

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("14B122D0-90BF-45AA-8B92-E02CD29784D3"),
            SubCategoryId = new Guid("5DCDA147-B9E1-4881-ADC9-C9ED4837C8CF")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("14B122D0-90BF-45AA-8B92-E02CD29784D3"),
            SubCategoryId = new Guid("DB6A3733-625E-4AD2-BDF5-32337A91DF12")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("14B122D0-90BF-45AA-8B92-E02CD29784D3"),
            SubCategoryId = new Guid("A9203C28-F272-4C4C-92B8-0D75352A31CB")
        };

        categoriesSubCategories.Add(categorySubCategory);

        // Seeding Scripts category

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("510AF335-4B59-49FE-8022-141F5CC410D4"),
            SubCategoryId = new Guid("5DCDA147-B9E1-4881-ADC9-C9ED4837C8CF")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("510AF335-4B59-49FE-8022-141F5CC410D4"),
            SubCategoryId = new Guid("DB6A3733-625E-4AD2-BDF5-32337A91DF12")
        };

        categoriesSubCategories.Add(categorySubCategory);

        categorySubCategory = new
        {
            GeneralCategoryId = new Guid("510AF335-4B59-49FE-8022-141F5CC410D4"),
            SubCategoryId = new Guid("A9203C28-F272-4C4C-92B8-0D75352A31CB")
        };

        categoriesSubCategories.Add(categorySubCategory);

        return categoriesSubCategories.ToArray();
    }
}
