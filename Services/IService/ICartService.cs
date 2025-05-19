namespace e_commerce.Services.IService;

public interface ICartService
{
    public Task<Result<CartResponse>> GetByCustomerIdAsync(string UserId, CancellationToken cancellationToken = default);
    public Task<Result<CartResponse>> AddAsync(string UserId, CartRequest request, CancellationToken cancellationToken = default);
    public Task<Result> RemoveItemAsync(string UserId, int itemId, CancellationToken cancellationToken = default);
    public Task<Result> ClearAsync(string UserId, CancellationToken cancellationToken = default);
}
