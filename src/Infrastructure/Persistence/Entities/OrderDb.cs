namespace Infrastructure.Persistence.Entities;

using Infrastructure.Persistence.Entities.Abstractions;

public sealed class OrderDb : Entity<int>
{
    public string OrderNumber { get; set; } = default!;
    public int CustomerId { get; set; }
    public string BillingStreet { get; set; } = default!;
    public string BillingHouseNumber { get; set; } = default!;
    public string BillingPostalCode { get; set; } = default!;
    public string BillingCity { get; set; } = default!;
    public string BillingCountry { get; set; } = default!;
    public string BillingState { get; set; } = default!;
    public string ShipmentStreet { get; set; } = default!;
    public string ShipmentHouseNumber { get; set; } = default!;
    public string ShipmentPostalCode { get; set; } = default!;
    public string ShipmentCity { get; set; } = default!;
    public string ShipmentCountry { get; set; } = default!;
    public string ShipmentState { get; set; } = default!;
    public string OrderStatus { get; set; } = default!;
    public string PaymentStatus { get; set; } = default!;
    public string ShipmentStatus { get; set; } = default!;
    public decimal SubtotalAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal ShipmentAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderItemDb> OrderItems { get; set; } = [];
}
