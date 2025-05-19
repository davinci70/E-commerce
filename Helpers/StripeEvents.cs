namespace e_commerce.Helpers;

public class StripeEvents
{
    public const string PaymentIntentSucceeded = "payment_intent.succeeded";
    public const string PaymentIntentFailed = "payment_intent.payment_failed";
}
