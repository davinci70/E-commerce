namespace e_commerce.Entities;

public class Review : AuditableEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public byte Rate { get; set; }
    public string Body { get; set; } = string.Empty;

    public Product Product { get; set; } = default!;
}
 