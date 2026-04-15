using Domain.Entities.Abstractions;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Inventories;

public sealed class Inventory(InventoryId id, ProductId productId, int quantity, int reservedQuantity, int reorderPoint, DateOnly? lastRestockDate = null) : AggregateRoot<InventoryId>(id)
{
    public ProductId ProductId { get; private set; } = productId;
    public int Quantity { get; private set; } = quantity;
    public int ReservedQuantity { get; private set; } = reservedQuantity;
    public int ReorderPoint { get; private set; } = reorderPoint;
    public DateOnly? LastRestockDate { get; private set; } = lastRestockDate;
}
