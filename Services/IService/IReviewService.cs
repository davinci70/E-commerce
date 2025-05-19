
namespace e_commerce.Services.IService;

public interface IReviewService
{
    Task<Result<ReviewResponse>> GetAsync(int Id, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ReviewResponse>>> GetUserReviewsAsync(string UserId, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<ReviewResponse>>> GetProductReviewsAsync(int productId, CancellationToken cancellationToken = default);
    Task<Result<ReviewResponse>> AddAsync(string UserId, ReviewRequest request, CancellationToken cancellationToken = default);
    Task<Result> UpdateAsync(int Id, string UserId, UpdateReviewRequest request, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(int Id, string UserId, CancellationToken cancellationToken = default);
    
}

