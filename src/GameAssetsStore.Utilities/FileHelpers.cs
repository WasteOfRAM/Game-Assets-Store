namespace GameAssetsStore.Utilities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

using static Common.EntityValidationConstants.Asset;

public static class FileHelpers
{
    private static readonly Dictionary<string, List<byte[]>> fileSignature = new Dictionary<string, List<byte[]>>
        {
            { ".jpeg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            { ".jpg", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                }
            },
            { ".zip", new List<byte[]>
                {
                    new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                    new byte[] { 0x50, 0x4B, 0x4C, 0x49, 0x54, 0x45 },
                    new byte[] { 0x50, 0x4B, 0x53, 0x70, 0x58 },
                    new byte[] { 0x50, 0x4B, 0x05, 0x06 },
                    new byte[] { 0x50, 0x4B, 0x07, 0x08 },
                    new byte[] { 0x57, 0x69, 0x6E, 0x5A, 0x69, 0x70 },
                }
            },
        };


    public static void FileValidation(IFormFile formFile, ModelStateDictionary modelState, int maxBytesSize)
    {
        if (formFile.FileName.Length > FileNameMaxLength)
        {
            modelState.AddModelError(string.Empty, $"File \"{formFile.FileName}\" file name exceeds maximum allowed {FileNameMaxLength}.");
        }

        if (formFile.Length > maxBytesSize)
        {
            modelState.AddModelError(string.Empty, $"File \"{formFile.FileName}\" is larger than the allowed max size.");
        }

        if (!IsValidFileExtensionAndSignature(formFile.FileName, formFile.OpenReadStream()))
        {
            modelState.AddModelError(string.Empty, $"File \"{formFile.FileName}\" has unsupported file format.");
        }
    }

    private static bool IsValidFileExtensionAndSignature(string fileName, Stream data)
    {
        if (string.IsNullOrEmpty(fileName) || data == null || data.Length == 0)
        {
            return false;
        }

        var ext = Path.GetExtension(fileName).ToLowerInvariant();

        if (string.IsNullOrEmpty(ext) || !fileSignature.ContainsKey(ext))
        {
            return false;
        }

        data.Position = 0;

        using (var reader = new BinaryReader(data))
        {
            var signatures = fileSignature[ext];
            var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

            return signatures.Any(signature =>
                headerBytes.Take(signature.Length).SequenceEqual(signature));
        }
    }
}
