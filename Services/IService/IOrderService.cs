namespace e_commerce.Services.IService;

public interface IOrderService
{
    public Task<Result<OrderResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<OrderResponse>> GetByUserIdAsync(string UserId, CancellationToken cancellationToken = default);
    public Task<Result<OrderResponse>> AddAsync(string UserId, OrderRequest request, CancellationToken cancellationToken = default);
    public Task<Result> UpdateAsync(int Id, string UserId, OrderRequest request, CancellationToken cancellationToken = default);
    public Task<Result> ToggleStatusAsync(int Id, string UserId, OrderStatus.enOrderStatus enStatus, CancellationToken cancellationToken = default);
}
