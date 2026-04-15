namespace Infrastructure.Persistence.Entities;

using Infrastructure.Persistence.Entities.Abstractions;

public sealed class ProductDb : Entity<int>
{
    public int? CategoryId { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public decimal Price { get; set; }
    public string CurrencyCode { get; set; } = default!;
    public string CurrencySymbol { get; set; } = default!;
    public int StockQuantity { get; set; }
    public bool IsActive { get; set; }
    public bool IsFeatured { get; set; }
}
