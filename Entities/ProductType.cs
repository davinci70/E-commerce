namespace e_commerce.Entities;

public class ProductType : AuditableEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ImageUrl {  get; set; } = string.Empty;

    public ICollection<Product> Products { get; set;} = [];
}
