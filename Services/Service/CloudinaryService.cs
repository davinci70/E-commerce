using CloudinaryDotNet.Actions;
using CloudinaryDotNet;

namespace e_commerce.Services.Service;

public class CloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IOptions<CloudinarySettings> config)
    {
        var account = new Account(
            config.Value.CloudName,
            config.Value.ApiKey,
            config.Value.ApiSecret
        );
        _cloudinary = new Cloudinary(account);
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, file.OpenReadStream()),
            Transformation = new Transformation().Width(500).Height(500).Crop("fill")
        };
        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

        return uploadResult.SecureUrl.ToString();
    }

    public async Task DeleteImageAsync(string imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
            throw new ArgumentException("Image URL cannot be null or empty.");

        // Extract the public ID from the image URL
        var publicId = ExtractPublicId(imageUrl);

        // Create deletion parameters
        var deletionParams = new DeletionParams(publicId);

        // Delete the image from Cloudinary
        var deletionResult = await _cloudinary.DestroyAsync(deletionParams);

        if (deletionResult.Error != null)
        {
            throw new Exception($"Error deleting image: {deletionResult.Error.Message}");
        }
    }

    private string ExtractPublicId(string imageUrl)
    {
        var uri = new Uri(imageUrl);
        var segments = uri.Segments;

        // Assuming the public ID is the last segment before the format (e.g., .jpg)
        return segments[segments.Length - 1].Split('.')[0];
    }
}
