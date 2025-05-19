namespace e_commerce.Services.IService;

public interface IPaymentService
{
    public Task<Result> CreatePaymentAsync(int orderId, string UserId, CancellationToken cancellationToken = default);
    public Task<Result> WebhookAsync(CancellationToken cancellationToken = default);
}
