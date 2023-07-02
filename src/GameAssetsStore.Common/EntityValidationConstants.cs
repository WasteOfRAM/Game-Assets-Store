namespace GameAssetsStore.Common;

public static class EntityValidationConstants
{
    public static class Seller
    {
        public const int SellerNameMinLength = 3;
        public const int SellerNameMaxLength = 50;
    }

    public static class Asset
    {
        public const int AssetNameMinLength = 3;
        public const int AssetNameMaxLength = 15;

        public const int VersionMaxLength = 10;
    }

    public static class Categories
    {
        public const int NameMaxLength = 20;
    }

    public static class ArtStyle
    {
        public const int NameMaxLength = 20;
    }

    public static class Review
    {
        public const int TextMinLength = 4;
        public const int TextMaxLength = 500;
    }
}
