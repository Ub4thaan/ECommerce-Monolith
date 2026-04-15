using Domain.Entities.Abstractions;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Catalogs;

public sealed class Product(ProductId id, CategoryId? categoryId, string name, string description, string slug, decimal price, string currencyCode, string currencySymbol, int stockQuantity, bool isActive, bool isFeatured) : AggregateRoot<ProductId>(id)
{
    public CategoryId? CategoryId { get; private set; } = categoryId;
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public string Slug { get; private set; } = slug;
    public decimal Price { get; private set; } = price;
    public string CurrencyCode { get; private set; } = currencyCode;
    public string CurrencySymbol { get; private set; } = currencySymbol;
    public int StockQuantity { get; private set; } = stockQuantity;
    public bool IsActive { get; private set; } = isActive;
    public bool IsFeatured { get; private set; } = isFeatured;
}
