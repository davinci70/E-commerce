namespace e_commerce.Entities;

public class ProductImage
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int ProductID { get; set; }

    public Product Product { get; set; } = default!;
}
