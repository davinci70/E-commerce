namespace e_commerce.Errors;

public class PaymentErrors
{
    public static Error CancelledOrder = 
        new("Payment.CancelledOrder", "Cannot pay for a cancelled error", StatusCodes.Status400BadRequest);

    public static Error PaidOrder = 
        new("Payment.PaidOrder", "This order is already paid", StatusCodes.Status400BadRequest);

    public static Error OngoingPayment = 
        new("Payment.OngoingPayment", "You already have an ongoing payment request", StatusCodes.Status400BadRequest);

    public static Error WebhookFailed = 
        new("Payment.WebhookFailed", "Webhook failed", StatusCodes.Status400BadRequest);

    
}
