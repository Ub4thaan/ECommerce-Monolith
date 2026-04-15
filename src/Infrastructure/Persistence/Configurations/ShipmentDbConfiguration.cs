namespace Infrastructure.Persistence.Configurations;

using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class ShipmentDbConfiguration : DbEntityTypeConfiguration<ShipmentDb, int>
{
    protected override void ConfigureEntity(EntityTypeBuilder<ShipmentDb> builder)
    {
        builder.ToTable("shipments");

        builder.Property(s => s.ShippingMethod)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.TrackingNumber)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(s => s.Carrier)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Street).IsRequired().HasMaxLength(200);
        builder.Property(s => s.HouseNumber).IsRequired().HasMaxLength(20);
        builder.Property(s => s.PostalCode).IsRequired().HasMaxLength(20);
        builder.Property(s => s.City).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Country).IsRequired().HasMaxLength(100);
        builder.Property(s => s.State).IsRequired().HasMaxLength(100);

        builder.Property(s => s.Status)
            .IsRequired()
            .HasMaxLength(50);
    }
}
