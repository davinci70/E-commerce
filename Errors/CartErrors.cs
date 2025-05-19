namespace e_commerce.Errors;

public class CartErrors
{
    public static Error EmptyCart =
        new("Cart.EmptyCart", "Your cart is empty", StatusCodes.Status204NoContent);
    
    public static Error ItemNotFound =
        new("Cart.ItemNotFound", "Item was not found in the cart", StatusCodes.Status404NotFound);
}
