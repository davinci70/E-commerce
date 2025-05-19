namespace e_commerce.Contracts.ProductTypes;

public class ProductTypeRequestValidator : AbstractValidator<ProductTypeRequest>
{
    public ProductTypeRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(3, 150);
    }
}
