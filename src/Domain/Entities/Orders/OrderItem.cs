using Domain.Entities.Abstractions;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Orders;

public sealed class OrderItem(OrderItemId id, ProductId productId, string ProductName, int quantity, decimal unitPrice, decimal discountAmount, decimal totalPrice) : Entity<OrderItemId>(id)
{
    public ProductId ProductId { get; private set; } = productId;
    public string ProductName { get; private set; } = ProductName;
    public int Quantity { get; private set; } = quantity;
    public decimal UnitPrice { get; private set; } = unitPrice;
    public decimal DiscountAmount { get; private set; } = discountAmount;
    public decimal TotalPrice { get; private set; } = totalPrice;
}
