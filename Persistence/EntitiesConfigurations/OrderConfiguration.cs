
namespace e_commerce.Persistence.EntitiesConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Ignore(x => x.UpdatedById);
        builder.Ignore(x => x.UpdatedBy);

        builder.Property(x => x.CreatedById)
            .HasColumnName("UserId");

        builder.Property(x => x.TotalPrice)
            .HasPrecision(10, 2);

        builder.Property(x => x.Status)
            .HasConversion<string>()
            .HasMaxLength(50);
    }
}
