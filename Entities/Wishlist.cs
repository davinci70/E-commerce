namespace e_commerce.Entities;

public class Wishlist
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;

    public ApplicationUser User { get; set; } = default!;
    public ICollection<WishlistItem> WishlistItems { get; set; } = [];
}
