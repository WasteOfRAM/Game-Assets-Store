﻿namespace GameAssetsStore.Common;

public static class EntityValidationConstants
{
    public static class ApplicationUser
    {
        public const int UserNameMinLength = 3;
        public const int UserNameMaxLength = 20;

        public const string UserNameAllowedCharacters = @"^[a-zA-Z0-9_.-]*$";
    }

    public static class Shop
    {
        public const int ShopNameMinLength = 3;
        public const int ShopNameMaxLength = 50;

        public const string ShopNameAllowedCharacters = @"^([a-zA-Z0-9.]*)([ \-_][a-zA-Z0-9.]+)*$";
    }

    public static class Asset
    {
        public const int AssetNameMinLength = 3;
        public const int AssetNameMaxLength = 30;

        public const string AssetNameAllowedCharacters = @"^([a-zA-Z0-9.]*)([ \-_][a-zA-Z0-9.]+)*$";

        public const int FileNameMinLength = 5;
        public const int FileNameMaxLength = 30;

        public const int DescriptionMaxLength = 1000;

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
        public const int AboutMaxLength = 500;
    }

    public static class SocialLink
    {
        public const int LinkMinLength = 3;
        public const int LinkMaxLength = 75;
    }
}
