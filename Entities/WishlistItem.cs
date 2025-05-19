namespace e_commerce.Entities;

public class WishlistItem
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int WishlistId { get; set; }

    public Product Product { get; set; } = default!;
    public Wishlist Wishlist { get; set; } = default!;
}
