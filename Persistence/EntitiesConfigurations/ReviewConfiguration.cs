
namespace e_commerce.Persistence.EntitiesConfigurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.Property(x => x.Body)
            .HasMaxLength(2000);

        builder.Property(x => x.CreatedById)
            .HasColumnName("UserId");

        builder.Ignore(x => x.UpdatedBy);
        builder.Ignore(x => x.UpdatedById);
    }
}
