namespace Infrastructure.Persistence.Configurations;

using Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public sealed class InventoryDbConfiguration : DbEntityTypeConfiguration<InventoryDb, int>
{
    protected override void ConfigureEntity(EntityTypeBuilder<InventoryDb> builder)
    {
        builder.ToTable("inventories");
    }
}
