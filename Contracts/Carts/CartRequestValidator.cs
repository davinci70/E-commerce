namespace e_commerce.Contracts.Carts;

public class CartRequestValidator : AbstractValidator<CartRequest>
{
    private readonly ApplicationDbContext _context;

    public CartRequestValidator(ApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.ProductId)
            .NotEmpty();

        RuleFor(x => x.Quantity)
            .NotEmpty()
            .Must(BeLessThanOrEqualToStock)
            .WithMessage("Quantity exceeds available stock.")
            .GreaterThan(0)
            .WithMessage("Invalid Quantity");
    }

    private bool BeLessThanOrEqualToStock(CartRequest request, int quantity)
    {
        var product = _context.Products
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == request.ProductId);

        return product != null && quantity <= product!.StockQuantity;
    }
}
