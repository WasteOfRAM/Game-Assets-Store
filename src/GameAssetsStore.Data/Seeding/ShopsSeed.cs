namespace GameAssetsStore.Data.Seeding;

using GameAssetsStore.Data.Models;

public static class ShopsSeed
{
    public static Shop[] GenerateShops()
    {
        ICollection<Shop> shops = new HashSet<Shop>();

        Shop shop;

        shop = new Shop
        {
            Id = new Guid("25C159F2-7159-4DA5-A5E1-8D0081C6E2E1"),
            OwningUserId = new Guid("37216E26-1916-41FB-B264-5D06F7872225"),
            ShopName = "Good Stuff"
        };

        shops.Add(shop);

        shop = new Shop
        {
            Id = new Guid("D83EDC2E-D407-4411-B750-E7E55FB28FC4"),
            OwningUserId = new Guid("AE3730FD-295E-4778-ABC4-8A636E9F645E"),
            ShopName = "User2"
        };

        shops.Add(shop);

        return shops.ToArray();
    }
}
