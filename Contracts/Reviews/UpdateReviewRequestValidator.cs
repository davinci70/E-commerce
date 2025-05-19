namespace e_commerce.Contracts.Reviews;

public class UpdateReviewRequestValidator : AbstractValidator<UpdateReviewRequest>
{
    public UpdateReviewRequestValidator()
    {
        RuleFor(x => x.Body)
            .NotEmpty();

        RuleFor(x => x.Rate)
            .Must(val => val >= 1 && val <= 5)
            .WithMessage("Rate must be between 1 and 5");
    }
}
