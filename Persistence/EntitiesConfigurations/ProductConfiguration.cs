
namespace e_commerce.Persistence.EntitiesConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasIndex(x => x.Name);
        builder.HasIndex(x => x.ProductTypeId);
        builder.HasIndex(p => new { p.ProductTypeId, p.Price });

        builder.Property(x => x.Name)
            .HasMaxLength(200);

        builder.Property(x => x.Description)
            .HasMaxLength(2000);

        builder.Property(x => x.SmallDescription)
            .HasMaxLength(500);

        builder.Property(x => x.Price)
            .HasPrecision(10, 2);
        
         builder.Property(x => x.Discount)
            .HasPrecision(10, 2);

        builder.Property(x => x.ThumbnailUrl)
            .HasMaxLength (200);
    }
}
