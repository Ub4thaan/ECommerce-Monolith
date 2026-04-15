using Domain.Entities.Abstractions;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Orders;

public sealed class Order(OrderId id, string orderNumber, CustomerId customerId, string billingStreet, string billingHouseNumber, string billingPostalCode, string billingCity, string billingCountry, string billingState, string shipmentStreet, string shipmentHouseNumber, string shipmentPostalCode, string shipmentCity, string shipmentCountry, string shipmentState, string orderStatus, string paymentStatus, string shipmentStatus, decimal subtotalAmount, decimal taxAmount, decimal shipmentAmount, decimal totalAmount, IEnumerable<OrderItem>? items = null) : AggregateRoot<OrderId>(id)
{
    public string OrderNumber { get; private set; } = orderNumber;
    public CustomerId CustomerId { get; private set; } = customerId;
    public string BillingStreet { get; private set; } = billingStreet;
    public string BillingHouseNumber { get; private set; } = billingHouseNumber;
    public string BillingPostalCode { get; private set; } = billingPostalCode;
    public string BillingCity { get; private set; } = billingCity;
    public string BillingCountry { get; private set; } = billingCountry;
    public string BillingState { get; private set; } = billingState;
    public string ShipmentStreet { get; private set; } = shipmentStreet;
    public string ShipmentHouseNumber { get; private set; } = shipmentHouseNumber;
    public string ShipmentPostalCode { get; private set; } = shipmentPostalCode;
    public string ShipmentCity { get; private set; } = shipmentCity;
    public string ShipmentCountry { get; private set; } = shipmentCountry;
    public string ShipmentState { get; private set; } = shipmentState;
    public string OrderStatus { get; private set; } = orderStatus;
    public string PaymentStatus { get; private set; } = paymentStatus;
    public string ShipmentStatus { get; private set; } = shipmentStatus;
    public decimal SubtotalAmount { get; private set; } = subtotalAmount;
    public decimal TaxAmount { get; private set; } = taxAmount;
    public decimal ShipmentAmount { get; private set; } = shipmentAmount;
    public decimal TotalAmount { get; private set; } = totalAmount;
    public IReadOnlyCollection<OrderItem> OrderItems => orderItems.AsReadOnly();

    private readonly List<OrderItem> orderItems = items?.ToList() ?? [];
}
