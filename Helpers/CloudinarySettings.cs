using System.ComponentModel.DataAnnotations;

namespace e_commerce.Helpers;

public class CloudinarySettings
{
    public static string SectionName = "Cloudinary";

    [Required]
    public string CloudName { get; set; } = string.Empty;

    [Required]
    public string ApiKey { get; set; } = string.Empty;

    [Required]
    public string ApiSecret { get; set; } = string.Empty;
}
