
namespace e_commerce.Services.Service;

public class OrderService(ApplicationDbContext context) : IOrderService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<OrderResponse>> AddAsync(string UserId, OrderRequest request, CancellationToken cancellationToken = default)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var UserHasAddress = await _context.Addresses.AnyAsync(a => a.Id == request.ShippingAddressId && a.UserId == UserId, cancellationToken);

            if (!UserHasAddress)
                return Result.Failure<OrderResponse>(AddressErrors.NonRelatedAddress);

            decimal totalPrice = 0;
            List<OrderItem> orderItems = [];

            foreach (var item in request.OrderItems)
            {
                if (await _context.Products.FindAsync(item.ProductId, cancellationToken) is not { } product)
                    return Result.Failure<OrderResponse>(ProductErrors.ProductNotFound);

                if (product.StockQuantity < item.Quantity)
                    return Result.Failure<OrderResponse>(ProductErrors.NotEnoughQuantity);

                if (item.Quantity <= 0)
                    return Result.Failure<OrderResponse>(ProductErrors.InvalidQuantity);

                var itemTotal = product.Price * item.Quantity;
                totalPrice += itemTotal;

                product.StockQuantity -= item.Quantity; // Deduct stock
                _context.Products.Update(product); // Track product update

                var orderItem = item.Adapt<OrderItem>();
                orderItem.ItemPrice = product.Price;
                orderItems.Add(orderItem);
            }

            var order = request.Adapt<Order>();
            order.OrderItems = orderItems;
            order.TotalPrice = totalPrice;

            await _context.Orders.AddAsync(order, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            order = await _context.Orders
                .Include(o => o.ShippingAddress)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .Include(o => o.CreatedBy)
                .FirstOrDefaultAsync(o => o.Id == order.Id, cancellationToken);

            var orderResponse = order.Adapt<OrderResponse>();

            await transaction.CommitAsync(cancellationToken);

            return Result.Success(orderResponse);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            return Result.Failure<OrderResponse>(OrderErrors.UnhandeledError);
        }

        
    }
    public async Task<Result<OrderResponse>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var order = await _context.Orders
            .Where(o => o.Id == id)
            .Include(oi => oi.OrderItems)
            .ProjectToType<OrderResponse>()
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);

        return order is not null ? Result.Success(order) : Result.Failure<OrderResponse>(OrderErrors.NotFound);
    }
    public async Task<IEnumerable<OrderResponse>> GetByUserIdAsync(string UserId, CancellationToken cancellationToken = default)
    {
        return await _context.Orders
            
            .Include(oi => oi.OrderItems)
            .Where(o => o.CreatedById == UserId)
            .ProjectToType<OrderResponse>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    }
    public async Task<Result> UpdateAsync(int Id, string UserId, OrderRequest request, CancellationToken cancellationToken = default)
    {
        var order = await _context.Orders
                .Include(oi => oi.OrderItems)
                .FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);

        if (order is null)
            return Result.Failure(OrderErrors.NotFound);

        if (order.Status == OrderStatus.enOrderStatus.Cancelled)
            return Result.Failure(OrderErrors.CancelledOrder);

        if (order.Status == OrderStatus.enOrderStatus.Shipped)
            return Result.Failure(OrderErrors.ShippedOrder);

        if (order.Status == OrderStatus.enOrderStatus.Delivered)
            return Result.Failure(OrderErrors.DeliveredOrder);

        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var UserHasAddress = await _context.Addresses.AnyAsync(a => a.Id == request.ShippingAddressId && a.UserId == UserId, cancellationToken);

            if (!UserHasAddress)
                return Result.Failure<OrderResponse>(AddressErrors.NonRelatedAddress);

            decimal totalPrice = 0;

            await RestoreOldItemsStock(order.OrderItems, cancellationToken);

            order.OrderItems.Clear();

            foreach (var item in request.OrderItems)
            {
                if (await _context.Products.FindAsync(item.ProductId, cancellationToken) is not { } product)
                    return Result.Failure<OrderResponse>(ProductErrors.ProductNotFound);

                if (product.StockQuantity < item.Quantity)
                    return Result.Failure<OrderResponse>(ProductErrors.NotEnoughQuantity);

                if (item.Quantity <= 0)
                    return Result.Failure<OrderResponse>(ProductErrors.InvalidQuantity);

                var itemTotal = product.Price * item.Quantity;
                totalPrice += itemTotal;

                product.StockQuantity -= item.Quantity; // Deduct stock
                _context.Products.Update(product); // Track product update

                var orderItem = item.Adapt<OrderItem>();
                orderItem.ItemPrice = product.Price;
                order.OrderItems.Add(orderItem);
            }

            order.TotalPrice = totalPrice;

            await _context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return Result.Success();
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            return Result.Failure<OrderResponse>(OrderErrors.UnhandeledError);
        }
    }
    public async Task<Result> ToggleStatusAsync(int Id, string UserId, OrderStatus.enOrderStatus enStatus, CancellationToken cancellationToken = default)
    {
        var order = await _context.Orders
            .FirstOrDefaultAsync(o => o.Id == Id && o.CreatedById == UserId, cancellationToken);

        if (order is null)
            return Result.Failure(OrderErrors.NotFound);

        order.Status = enStatus;

        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
    private async Task RestoreOldItemsStock(IEnumerable<OrderItem> OrderItems, CancellationToken cancellationToken)
    {
        foreach (var existingItem in OrderItems)
        {
            var product = await _context.Products.FindAsync(existingItem.ProductId);
            if (product is not null)
            {
                product.StockQuantity += existingItem.Quantity;
                _context.Products.Update(product);
            }
        }
    }
}
