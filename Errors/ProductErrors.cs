namespace e_commerce.Errors;

public class ProductErrors
{
    public static Error ProductNotFound =
        new("Product.NotFound", "Product is not found", StatusCodes.Status400BadRequest);
    
    public static Error NotEnoughQuantity =
        new("Product.NotEnoughQuantity", "You've requested more than the available in the stock", StatusCodes.Status400BadRequest);
  
    public static Error InvalidQuantity =
        new("Product.InvalidQuantity", "The quantity you entered is not valid", StatusCodes.Status400BadRequest);
    
    public static Error ProductRemovedFromCart =
        new("Product.ProductRemovedFromCart", "Product was removed from shopping cart", StatusCodes.Status204NoContent);
}
