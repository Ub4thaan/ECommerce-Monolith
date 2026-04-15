using Domain.Entities.Abstractions;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Payments;

public sealed class Payment(PaymentId id, OrderId orderId, string paymentMethod, string status,string transactionId, decimal amount, string currencyCode, string currencySymbol, DateOnly paymentDate) : AggregateRoot<PaymentId>(id)
{
    public OrderId OrderId { get; private set; } = orderId;
    public string PaymentMethod { get; private set; } = paymentMethod;
    public string Status { get; private set; } = status;
    public string TransactionId { get; private set; } = transactionId;
    public decimal Amount { get; private set; } = amount;
    public string CurrencyCode { get; private set; } = currencyCode;
    public string CurrencySymbol { get; private set; } = currencySymbol;
    public DateOnly PaymentDate { get; private set; } = paymentDate;
}
