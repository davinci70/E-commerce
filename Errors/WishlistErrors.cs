namespace e_commerce.Errors;

public class WishlistErrors
{
    public static Error NotFound = 
        new("Wishlist.NotFound", "Wishlist is not found", StatusCodes.Status404NotFound);

    public static Error ProductWishlisted = 
        new("Wishlist.ProductWishlisted", "Product is already wishlisted", StatusCodes.Status400BadRequest);

    public static Error ProductNotWishlisted = 
        new("Wishlist.ProductNotWishlisted", "Product is not wishlisted", StatusCodes.Status400BadRequest);
}
