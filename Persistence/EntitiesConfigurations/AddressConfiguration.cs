
namespace e_commerce.Persistence.EntitiesConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.Property(x => x.Street).HasMaxLength(150);
        builder.Property(x => x.State).HasMaxLength(150);
        builder.Property(x => x.City).HasMaxLength(150);
        builder.Property(x => x.PostalCode).HasMaxLength(15);
    }
}
