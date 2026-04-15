namespace Infrastructure.Persistence.Entities;

using Infrastructure.Persistence.Entities.Abstractions;

public sealed class InventoryDb : Entity<int>
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int ReorderPoint { get; set; }
    public DateOnly? LastRestockDate { get; set; }
}
