namespace e_commerce.Entities;

public class Product : AuditableEntity
{
    public int Id { get; set; }
    public int ProductTypeId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SmallDescription { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public int StockQuantity { get; set; }
    public string? ThumbnailUrl { get; set; } = null;
    public bool IsDeleted { get; set; }

    public ProductType ProductType { get; set; } = default!;

    public ICollection<ProductImage> ProductImages { get; set; } = [];
    public ICollection<CartItem> CartItems { get; set; } = [];
}
