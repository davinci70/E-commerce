
namespace e_commerce.Settings;

public class StripeSettings
{
    public static string SectionName = "Stripe";

    [Required]
    public string SecretKey { get; set; } = string.Empty;

    [Required]
    public string PublishableKey { get; set; } = string.Empty;

    [Required]
    public string WebhookSecret { get; set; } = string.Empty;
}
