
namespace e_commerce.Persistence.EntitiesConfigurations;

public class CartConfiguration : IEntityTypeConfiguration<Cart>
{
    public void Configure(EntityTypeBuilder<Cart> builder)
    {
        builder.Ignore(x => x.UpdatedById);
        builder.Ignore(x => x.UpdatedBy);

        builder.Property(x => x.CreatedById)
            .HasColumnName("UserId");

        builder.Property(x => x.TotalPrice)
            .HasPrecision(10, 2);
    }
}
