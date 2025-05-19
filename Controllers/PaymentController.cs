
namespace e_commerce.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController(IPaymentService paymentService) : ControllerBase
{
    private readonly IPaymentService _paymentService = paymentService;

    [HttpPost("{orderId}")]
    [HasPermission(Permissions.CreatePayment)]
    public async Task<IActionResult> Pay(int orderId, CancellationToken cancellationToken)
    {
        var result = await _paymentService.CreatePaymentAsync(orderId, User.GetUserId()!, cancellationToken);

        return result.IsSuccess
            ? Ok(result)
            : result.ToProplem();
    }
    
    [HttpPost("webhook")]
    [HasPermission(Permissions.Webhook)]
    public async Task<IActionResult> Webhook(CancellationToken cancellationToken)
    {
        var result = await _paymentService.WebhookAsync(cancellationToken);

        return result.IsSuccess
            ? Ok(result)
            : result.ToProplem();
    }
}
