
namespace e_commerce.Services.Service;

public class ReviewService(ApplicationDbContext context) : IReviewService
{
    private readonly ApplicationDbContext _context = context;


    public async Task<Result<ReviewResponse>> AddAsync(string UserId, ReviewRequest request, CancellationToken cancellationToken = default)
    {
        var review = request.Adapt<Review>();
        review.CreatedById = UserId;

        await _context.Reviews.AddAsync(review, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success(review.Adapt<ReviewResponse>());
    }

    public async Task<Result> DeleteAsync(int Id, string UserId, CancellationToken cancellationToken = default)
    {
        var review = await _context.Reviews
            .FirstOrDefaultAsync(x => x.Id == Id && x.CreatedById == UserId, cancellationToken);

        if (review is null)
            return Result.Failure(ReviewErrors.NotFound);

        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<ReviewResponse>> GetAsync(int Id, CancellationToken cancellationToken = default)
    {
        var review = await _context.Reviews
            .Where(x => x.Id == Id)
            .ProjectToType<ReviewResponse>()
            .AsNoTracking()            
            .FirstOrDefaultAsync(cancellationToken);

        return review is not null ? Result.Success(review) : Result.Failure<ReviewResponse>(ReviewErrors.NotFound);
    }

    public async Task<Result<IEnumerable<ReviewResponse>>> GetUserReviewsAsync(string UserId, CancellationToken cancellationToken = default)
    {
        var review = await _context.Reviews
            .Where(x => x.CreatedById == UserId)
            .AsNoTracking()
            .ProjectToType<ReviewResponse>()
            .ToListAsync(cancellationToken);

        return review is not null ? Result.Success<IEnumerable<ReviewResponse>>(review) : Result.Failure<IEnumerable<ReviewResponse>>(ReviewErrors.NotFound);
    }
    
    public async Task<Result<IEnumerable<ReviewResponse>>> GetProductReviewsAsync(int productId, CancellationToken cancellationToken = default)
    {
        var review = await _context.Reviews
            .Where (x => x.ProductId == productId)
            .AsNoTracking()
            .ProjectToType<ReviewResponse>()
            .ToListAsync(cancellationToken);

        return review is not null ? Result.Success<IEnumerable<ReviewResponse>>(review) : Result.Failure<IEnumerable<ReviewResponse>>(ReviewErrors.NotFound);
    }

    public async Task<Result> UpdateAsync(int Id, string UserId, UpdateReviewRequest request, CancellationToken cancellationToken = default)
    {
        var review = await _context.Reviews
            .FirstOrDefaultAsync(x => x.Id == Id && x.CreatedById == UserId, cancellationToken);

        if (review is null)
            return Result.Failure(ReviewErrors.NotFound);

        review = request.Adapt(review);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
