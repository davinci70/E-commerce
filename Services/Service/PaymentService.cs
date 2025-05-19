
using Stripe;

namespace e_commerce.Services.Service;

public class PaymentService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IOptions<StripeSettings> stripeSettings) : IPaymentService
{
    private readonly ApplicationDbContext _context = context;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly StripeSettings _stripeSettings = stripeSettings.Value;

    public async Task<Result> CreatePaymentAsync(int orderId, string UserId, CancellationToken cancellationToken = default)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(x => x.Id == orderId && x.CreatedById == UserId, cancellationToken);

        if (order is null)
            return Result.Failure(OrderErrors.NotFound);

        if (order.Status == OrderStatus.enOrderStatus.Cancelled)
            return Result.Failure(PaymentErrors.CancelledOrder);

        var payment = await _context.Payments
                .Include(o => o.Order)
                .FirstOrDefaultAsync(o => o.OrderId == orderId && o.Order.CreatedById == UserId, cancellationToken);


        if (payment is not null && payment.IsPaid)
            return Result.Failure(PaymentErrors.PaidOrder);
        
        if (payment is not null)
            return Result.Failure(PaymentErrors.OngoingPayment);

        StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

        var options = new PaymentIntentCreateOptions
        {
            Amount = (long)(order.TotalPrice * 100), // Stripe expects amount in cents
            Currency = "egp",
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
            {
                Enabled = true
            },
            Metadata = new Dictionary<string, string>
            {
                { "orderId", order.Id.ToString() },
                { "userId", UserId }
            }
        };

        var service = new PaymentIntentService();
        var paymentIntent = await service.CreateAsync(options);

        // Save payment record (if it doesn't exist yet)
        if (payment is null)
        {
            var newPayment = new Payment
            {
                OrderId = order.Id,
                Amount = order.TotalPrice,
                Provider = "Stripe",
                IsPaid = false
            };

            _context.Payments.Add(newPayment);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return Result.Success(paymentIntent.ClientSecret);
    }
    public async Task<Result> WebhookAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var json = await new StreamReader(_httpContextAccessor.HttpContext!.Request.Body)
        .ReadToEndAsync(cancellationToken);

            var stripeSignature = _httpContextAccessor.HttpContext!.Request.Headers["Stripe-Signature"];

            var stripeEvent = EventUtility.ConstructEvent(
                json,
                stripeSignature,
                _stripeSettings.WebhookSecret
            );

            if (stripeEvent.Type == StripeEvents.PaymentIntentSucceeded)
            {
                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                var orderId = int.Parse(paymentIntent!.Metadata["orderId"]);

                var payment = await _context.Payments
                    .FirstOrDefaultAsync(p => p.OrderId == orderId, cancellationToken);

                if (payment is not null)
                {
                    payment.IsPaid = true;
                    _context.Payments.Update(payment);

                    var order = await _context.Orders.FindAsync(new object[] { orderId }, cancellationToken);
                    if (order is not null)
                        order.Status = OrderStatus.enOrderStatus.Processing;

                    await _context.SaveChangesAsync(cancellationToken);
                }
            }

            return Result.Success();
        }
        catch
        {
            return Result.Failure(PaymentErrors.WebhookFailed);
        }       
    }
}
