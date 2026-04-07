using Domain.Entities.Abstractions;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Domain.Entities.Catalog;

public sealed class Category(CategoryId id,string name, string description, string slug, CategoryId? parentCategoryId, bool isActive, bool isFeatured) : AggregateRoot<CategoryId>(id)
{
    public string Name { get; private set; } = name;
    public string Description { get; private set; } = description;
    public string Slug { get; private set; } = slug;
    public CategoryId? ParentCategoryId { get; private set; } = parentCategoryId;
    public bool IsActive { get; private set; } = isActive;
    public bool IsFeatured { get; private set; } = isFeatured;
}
