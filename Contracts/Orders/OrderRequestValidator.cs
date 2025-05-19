namespace e_commerce.Contracts.Orders;

public class OrderRequestValidator : AbstractValidator<OrderRequest>
{

    public OrderRequestValidator()
    {
        RuleFor(x => x.ShippingAddressId)
            .NotEmpty();

        RuleFor(x => x.OrderItems)
            .NotEmpty();
    }
}
