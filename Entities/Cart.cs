namespace e_commerce.Entities;

public class Cart : AuditableEntity
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }

    public ICollection<CartItem> CartItems { get; set; } = [];
}
