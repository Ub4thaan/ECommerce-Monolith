namespace Infrastructure.Persistence.Configurations;

using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class OrderDbConfiguration : DbEntityTypeConfiguration<OrderDb, int>
{
    protected override void ConfigureEntity(EntityTypeBuilder<OrderDb> builder)
    {
        builder.ToTable("orders");

        builder.Property(o => o.OrderNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(o => o.OrderNumber)
            .IsUnique();

        builder.Property(o => o.BillingStreet).IsRequired().HasMaxLength(200);
        builder.Property(o => o.BillingHouseNumber).IsRequired().HasMaxLength(20);
        builder.Property(o => o.BillingPostalCode).IsRequired().HasMaxLength(20);
        builder.Property(o => o.BillingCity).IsRequired().HasMaxLength(100);
        builder.Property(o => o.BillingCountry).IsRequired().HasMaxLength(100);
        builder.Property(o => o.BillingState).IsRequired().HasMaxLength(100);

        builder.Property(o => o.ShipmentStreet).IsRequired().HasMaxLength(200);
        builder.Property(o => o.ShipmentHouseNumber).IsRequired().HasMaxLength(20);
        builder.Property(o => o.ShipmentPostalCode).IsRequired().HasMaxLength(20);
        builder.Property(o => o.ShipmentCity).IsRequired().HasMaxLength(100);
        builder.Property(o => o.ShipmentCountry).IsRequired().HasMaxLength(100);
        builder.Property(o => o.ShipmentState).IsRequired().HasMaxLength(100);

        builder.Property(o => o.OrderStatus).IsRequired().HasMaxLength(50);
        builder.Property(o => o.PaymentStatus).IsRequired().HasMaxLength(50);
        builder.Property(o => o.ShipmentStatus).IsRequired().HasMaxLength(50);

        builder.Property(o => o.SubtotalAmount).HasPrecision(18, 2);
        builder.Property(o => o.TaxAmount).HasPrecision(18, 2);
        builder.Property(o => o.ShipmentAmount).HasPrecision(18, 2);
        builder.Property(o => o.TotalAmount).HasPrecision(18, 2);

        builder.HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
