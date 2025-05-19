
namespace e_commerce.Services.Service;

public class WishlistService(ApplicationDbContext context) : IWishlistService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<WishlistResponse>> AddAsync(string UserId, WishlistRequest request, CancellationToken cancellationToken = default)
    {
        if (await _context.Products.FindAsync(request.ProductId, cancellationToken) is not { } product)
            return Result.Failure<WishlistResponse>(ProductErrors.ProductNotFound);
        
        var wishlist = await _context.Wishlists
            .Include(x => x.WishlistItems)
            .FirstOrDefaultAsync(x => x.UserId == UserId, cancellationToken);

        if (wishlist is null)
        {
            wishlist = new Wishlist
            {
                UserId = UserId,
                WishlistItems =
                    [
                        new() {
                            ProductId = request.ProductId
                        }
                    ]
            };

            await _context.Wishlists.AddAsync(wishlist, cancellationToken);
        }
        else
        {
            if (wishlist.WishlistItems.Any(x => x.ProductId == request.ProductId))
                return Result.Failure<WishlistResponse>(WishlistErrors.ProductWishlisted);

            wishlist.WishlistItems.Add(new WishlistItem
            {
                ProductId = request.ProductId
            });
        }

        await _context.SaveChangesAsync(cancellationToken);

        var response = await _context.Wishlists
            .Where(x => x.Id == wishlist.Id)
            .ProjectToType<WishlistResponse>()
            .FirstOrDefaultAsync(cancellationToken);

        return Result.Success(response!);
    }

    public async Task<Result> ClearAsync(string UserId, CancellationToken cancellationToken = default)
    {
        var wishlist = await _context.Wishlists.FirstOrDefaultAsync(x => x.UserId == UserId, cancellationToken);

        if (wishlist is null)
            return Result.Failure(WishlistErrors.NotFound);

        _context.Wishlists.Remove(wishlist);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result<WishlistResponse>> GetByCustomerIdAsync(string UserId, CancellationToken cancellationToken = default)
    {
        var wishlist = await _context.Wishlists
            .Where(x => x.UserId == UserId)
            .Include(x => x.WishlistItems)           
            .ProjectToType<WishlistResponse>()
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);
            

        return wishlist is null ? Result.Failure<WishlistResponse>(WishlistErrors.NotFound) : Result.Success(wishlist);
    }

    public async Task<Result> RemoveItemAsync(int ItemId, string UserId, CancellationToken cancellationToken = default)
    {
        var wishlist = await _context.Wishlists
                .Include(x => x.WishlistItems)
                .FirstOrDefaultAsync(x => x.UserId == UserId, cancellationToken);

        if (wishlist is null)
            return Result.Failure(WishlistErrors.NotFound);

        if (!wishlist.WishlistItems.Any(x => x.ProductId == ItemId))
            return Result.Failure(WishlistErrors.ProductNotWishlisted);

        _context.WishlistItems.Remove(wishlist.WishlistItems.FirstOrDefault(x => x.ProductId == ItemId)!);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}