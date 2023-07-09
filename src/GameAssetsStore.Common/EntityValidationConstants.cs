namespace GameAssetsStore.Common;

public static class EntityValidationConstants
{
    public static class ApplicationUser
    {
        public const int UserNameMinLength = 3;
        public const int UserNameMaxLength = 20;

        public const string UserNameAllowedCharacters = @"^[a-zA-Z0-9_.]*$";
    }

    public static class Shop
    {
        public const int ShopNameMinLength = 3;
        public const int ShopNameMaxLength = 50;
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

    public static class UserProfile
    {
        public const int AboutMaxLength = 1500;
    }

    public static class Socials
    {
        public const int LinksMaxLength = 75;
    }
}
