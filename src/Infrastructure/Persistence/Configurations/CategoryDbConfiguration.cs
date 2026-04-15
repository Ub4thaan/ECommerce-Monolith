namespace Infrastructure.Persistence.Configurations;

using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class CategoryDbConfiguration : DbEntityTypeConfiguration<CategoryDb, int>
{
    protected override void ConfigureEntity(EntityTypeBuilder<CategoryDb> builder)
    {
        builder.ToTable("categories");

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(c => c.Slug)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(c => c.Slug)
            .IsUnique();
    }
}
