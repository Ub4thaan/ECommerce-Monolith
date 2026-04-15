namespace Infrastructure.Persistence.Configurations;

using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class PaymentDbConfiguration : DbEntityTypeConfiguration<PaymentDb, int>
{
    protected override void ConfigureEntity(EntityTypeBuilder<PaymentDb> builder)
    {
        builder.ToTable("payments");

        builder.Property(p => p.PaymentMethod)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.TransactionId)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Amount)
            .HasPrecision(18, 2);

        builder.Property(p => p.CurrencyCode)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(p => p.CurrencySymbol)
            .IsRequired()
            .HasMaxLength(5);
    }
}
