namespace e_commerce.Errors;

public class OrderErrors
{
    public static Error NotFound =
        new("Order.NotFound", "No order was found", StatusCodes.Status404NotFound);
    
    public static Error UnhandeledError =
        new("Order.UnhandeledError", "Something went wrong", StatusCodes.Status400BadRequest);

    public static Error ShippedOrder =
        new("Order.ShippedOrder", "Order is already shipped and cannot be updated", StatusCodes.Status400BadRequest);
    
    public static Error DeliveredOrder =
        new("Order.DeliveredOrder", "Order is already delivered and cannot be updated", StatusCodes.Status400BadRequest);
    
    public static Error CancelledOrder =
        new("Order.CancelledOrder", "Order has been cancelled and cannot be updated", StatusCodes.Status400BadRequest);

    public static Error EmptyOrderItems =
        new("Order.EmptyOrderItems", "Order items should not be empty", StatusCodes.Status400BadRequest);
}
