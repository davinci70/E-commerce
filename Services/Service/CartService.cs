
namespace e_commerce.Services.Service;

public class CartService(ApplicationDbContext context) : ICartService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<CartResponse>> GetByCustomerIdAsync(string UserId, CancellationToken cancellationToken = default)
    {
        var cart = await _context.Carts
            .Where(x => x.CreatedById == UserId)
            .Include(x => x.CartItems)
            .ProjectToType<CartResponse>()
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        return cart is null ? Result.Failure<CartResponse>(CartErrors.EmptyCart) : Result.Success(cart);
    }
    public async Task<Result<CartResponse>> AddAsync(string UserId, CartRequest request, CancellationToken cancellationToken = default)
    {
        var product = await _context.Products.FindAsync(request.ProductId, cancellationToken);

        if (product == null)
            return Result.Failure<CartResponse>(ProductErrors.ProductNotFound);

        var cart = await _context.Carts
            .Include(x => x.CartItems)
            .ThenInclude(x => x.Product)
            .ThenInclude(x => x.ProductImages)
            .FirstOrDefaultAsync(x => x.CreatedById == UserId, cancellationToken);

        if (cart == null)
        {
            cart = new Cart
            {
                CartItems = [],
                TotalPrice = 0m,
            };

            await _context.Carts.AddAsync(cart, cancellationToken);
        }

        var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == request.ProductId);

        if (existingItem != null)
        {
            existingItem.Quantity += request.Quantity;

            if (existingItem.Quantity > product.StockQuantity)
                return Result.Failure<CartResponse>(ProductErrors.NotEnoughQuantity);

            if (existingItem.Quantity <= 0)
            {
                _context.CartItems.Remove(existingItem);
                await _context.SaveChangesAsync(cancellationToken);

                return Result.Failure<CartResponse>(ProductErrors.ProductRemovedFromCart);
            }
        }
        else
        {
            cart.CartItems.Add(new CartItem
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity,
            });
        }

        cart.TotalPrice = cart.CartItems.Sum(ci =>
        {
            var prod = _context.Products.FirstOrDefault(p => p.Id == ci.ProductId);

            return prod != null ? 
                (prod.Discount > 0 ? ((prod.Price - prod.Discount) * ci.Quantity) : prod.Price * ci.Quantity)
                : 0;
        });

        await _context.SaveChangesAsync(cancellationToken);

        // Reload the cart with related data
        var updatedCart = await _context.Carts
            .Where(c => c.Id == cart.Id)
            .ProjectToType<CartResponse>()
            .FirstOrDefaultAsync(cancellationToken);

        return Result.Success(updatedCart!);
    }
    public async Task<Result> ClearAsync(string UserId, CancellationToken cancellationToken = default)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(x => x.CreatedById == UserId, cancellationToken);

        if (cart is null)
            return Result.Failure(CartErrors.EmptyCart);

        _context.Carts.Remove(cart);
        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
    public async Task<Result> RemoveItemAsync(string UserId, int itemId, CancellationToken cancellationToken = default)
    {
        var cart = await _context.Carts
            .Include(x => x.CartItems)
            .FirstOrDefaultAsync(x => x.CreatedById == UserId, cancellationToken);

        if (cart is null)
            return Result.Failure(CartErrors.EmptyCart);

        if (!cart.CartItems.Any(x => x.ProductId == itemId))
            return Result.Failure(CartErrors.ItemNotFound);

        cart.CartItems.Remove(cart.CartItems.FirstOrDefault(x => x.ProductId == itemId)!);

        await _context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
   

}
