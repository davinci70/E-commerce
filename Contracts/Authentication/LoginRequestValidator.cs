namespace e_commerce.Contracts.Authentication;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.password).NotEmpty();
    }
}
