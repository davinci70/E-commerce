namespace e_commerce.Errors;

public class ReviewErrors
{
    public static Error NotFound = 
        new("Review.NotFound", "Review is not found", StatusCodes.Status400BadRequest);
}
