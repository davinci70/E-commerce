namespace e_commerce.Contracts.Addresses;

public class AddressRequestValidator : AbstractValidator<AddressRequest>
{
    public AddressRequestValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty()
            .Length(3, 150);

         RuleFor(x => x.City)
            .NotEmpty()
            .Length(3, 150);

         RuleFor(x => x.State)
            .NotEmpty()
            .Length(3, 150);
        
        RuleFor(x => x.PostalCode)
            .NotEmpty()
            .Length(3, 15);

    }
}
