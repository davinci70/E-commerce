namespace e_commerce.Abstractions.Consts;

public class OrderStatus
{
    public enum enOrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }
}
