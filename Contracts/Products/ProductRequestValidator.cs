public class ProductRequestValidator : AbstractValidator<ProductRequest>
{
    public ProductRequestValidator()
    {
        RuleFor(x => x.Name)
            .Length(3, 200)
            .NotEmpty();

        RuleFor(x => x.Description)
            .Length(3, 2000)
            .NotEmpty();

        RuleFor(x => x.SmallDescription)
            .Length(3, 500)
            .NotEmpty();

        RuleFor(x => x.Price)
            .PrecisionScale(10, 2, true)
            .NotEmpty();

        RuleFor(x => x.Discount)
            .PrecisionScale(10, 2, true);

        RuleFor(x => x.StockQuantity)
            .Must(x => x > 0)
            .WithMessage("Stock quantity should be at least one or more");
    }
}
