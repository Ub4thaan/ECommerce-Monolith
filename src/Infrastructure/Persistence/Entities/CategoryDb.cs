namespace Infrastructure.Persistence.Entities;

using Infrastructure.Persistence.Entities.Abstractions;

public sealed class CategoryDb : Entity<int>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public int? ParentCategoryId { get; set; }
    public bool IsActive { get; set; }
    public bool IsFeatured { get; set; }
}
