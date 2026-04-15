namespace Infrastructure.Persistence.Entities;

using Infrastructure.Persistence.Entities.Abstractions;

public sealed class ShipmentDb : Entity<int>
{
    public int OrderId { get; set; }
    public string ShippingMethod { get; set; } = default!;
    public string TrackingNumber { get; set; } = default!;
    public string Carrier { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string HouseNumber { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Status { get; set; } = default!;
    public DateOnly ShippedAt { get; set; }
    public DateOnly EstimatedDeliveryDate { get; set; }
}
