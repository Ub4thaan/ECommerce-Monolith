namespace Infrastructure.Persistence.Configurations;

using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class ProductDbConfiguration : DbEntityTypeConfiguration<ProductDb, int>
{
    protected override void ConfigureEntity(EntityTypeBuilder<ProductDb> builder)
    {
        builder.ToTable("products");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(p => p.Slug)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(p => p.Slug)
            .IsUnique();

        builder.Property(p => p.Price)
            .HasPrecision(18, 2);

        builder.Property(p => p.CurrencyCode)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(p => p.CurrencySymbol)
            .IsRequired()
            .HasMaxLength(5);
    }
}
