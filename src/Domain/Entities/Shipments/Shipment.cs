using Domain.Entities.Abstractions;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Shipments;

public sealed class Shipment(ShipmentId id, OrderId orderId, string shippingMethod, string trackingNumber, string carrier, string street, string houseNumber, string postalCode, string city, string country, string state, string status, DateOnly shippedAt, DateOnly estimatedDeliveryDate) : AggregateRoot<ShipmentId>(id)
{
    public OrderId OrderId { get; private set; } = orderId;
    public string ShippingMethod { get; private set; } = shippingMethod;
    public string TrackingNumber { get; private set; } = trackingNumber;
    public string Carrier { get; private set; } = carrier;
    public string Street { get; private set; } = street;
    public string HouseNumber { get; private set; } = houseNumber;
    public string PostalCode { get; private set; } = postalCode;
    public string City { get; private set; } = city;
    public string Country { get; private set; } = country;
    public string State { get; private set; } = state;
    public string Status { get; private set; } = status;
    public DateOnly ShippedAt { get; private set; } = shippedAt;
    public DateOnly EstimatedDeliveryDate { get; private set; } = estimatedDeliveryDate;
}
