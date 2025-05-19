
namespace e_commerce.Services.IService;

public interface IWishlistService
{
    Task<Result<WishlistResponse>> GetByCustomerIdAsync(string UserId, CancellationToken cancellationToken = default);
    Task<Result<WishlistResponse>> AddAsync(string UserId, WishlistRequest request, CancellationToken cancellationToken = default);
    Task<Result> RemoveItemAsync(int ItemId, string UserId, CancellationToken cancellationToken = default);
    Task<Result> ClearAsync(string UserId, CancellationToken cancellationToken = default);
}
