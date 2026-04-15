namespace Infrastructure.Persistence.Entities;

using Infrastructure.Persistence.Entities.Abstractions;

public sealed class PaymentDb : Entity<int>
{
    public int OrderId { get; set; }
    public string PaymentMethod { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string TransactionId { get; set; } = default!;
    public decimal Amount { get; set; }
    public string CurrencyCode { get; set; } = default!;
    public string CurrencySymbol { get; set; } = default!;
    public DateOnly PaymentDate { get; set; }
}
