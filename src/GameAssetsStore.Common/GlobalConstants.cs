namespace GameAssetsStore.Common;

public static class GlobalConstants
{
    public const int AssetImagesMaxCount = 10;

    public const string AWSS3AssetsBucketName = "gas.assets";
    public const string AWSS3ImagesBucketName = "gas.images";

    public const string AWSS3Region = "eu-central-1";

    /// <summary>
    /// AWS S3 Image url constructor
    /// 
    /// 0 - region
    /// 1 - asset Id/aws folder
    /// 2 - image name
    /// </summary>
    /// <prop name="AWSS3ImageUrl"></prop>
    public const string AWSS3ImageUrl = "https://s3.{0}.amazonaws.com/gas.images/{1}/{2}";

    /// <summary>
    /// Max upload size in bytes.
    /// </summary>
    /// <prop name="MaxFileUploadSize"></prop>
    public const int MaxFileUploadSize = 524288000;

    /// <summary>
    /// Max image upload size in bytes.
    /// </summary>
    /// <prop name="MaxImageUploadSize"></prop>
    public const int MaxImageUploadSize = 2097152;
}