namespace e_commerce.Contracts.Wishlists;

public class WishlistRequestValidator : AbstractValidator<WishlistRequest>
{
    public WishlistRequestValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();
    }
}
