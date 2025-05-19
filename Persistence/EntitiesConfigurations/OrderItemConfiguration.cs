
namespace e_commerce.Persistence.EntitiesConfigurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(x => x.ItemPrice)
            .HasPrecision(10, 2);
    }
}
