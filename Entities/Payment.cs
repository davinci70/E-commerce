namespace e_commerce.Entities;

public class Payment : AuditableEntity
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public decimal Amount { get; set; }
    public string Provider {  get; set; } = string.Empty;
    public bool IsPaid { get; set; }

    public Order Order { get; set; } = default!;
}
