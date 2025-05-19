
namespace e_commerce.Persistence.EntitiesConfigurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.Ignore(x => x.UpdatedById);
        builder.Ignore(x => x.UpdatedBy);
        builder.Ignore(x => x.CreatedById);
        builder.Ignore(x => x.CreatedBy);

        builder.Property(x => x.Amount)
            .HasPrecision(10, 2);
    }
}
