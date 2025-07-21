namespace e_commerce.Entities;

public class Order : AuditableEntity
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public OrderStatus.enOrderStatus Status { get; set; } 
    public int ShippingAddressId { get; set; }

    public Address ShippingAddress { get; set; } = default!;
    public Payment Payment { get; set; } = default!;
    public ICollection<OrderItem> OrderItems { get; set; } = [];
}
