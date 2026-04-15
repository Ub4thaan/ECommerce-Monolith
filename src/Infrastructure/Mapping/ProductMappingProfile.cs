namespace Infrastructure.Mapping;

using AutoMapper;
using Domain.Entities.Catalogs;
using Domain.Primitives;
using Infrastructure.Persistence.Entities;

public sealed class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDb>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.Value))
            .ForMember(d => d.CategoryId, o => o.MapFrom(s => s.CategoryId != null ? (int?)s.CategoryId.Value : null))
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.UpdatedAt, o => o.Ignore())
            .ForMember(d => d.IsDeleted, o => o.Ignore())
            .ForMember(d => d.DeletedAt, o => o.Ignore());

        CreateMap<ProductDb, Product>()
            .ConstructUsing(src => new Product(
                new ProductId(src.Id),
                src.CategoryId.HasValue ? new CategoryId(src.CategoryId.Value) : null,
                src.Name,
                src.Description,
                src.Slug,
                src.Price,
                src.CurrencyCode,
                src.CurrencySymbol,
                src.StockQuantity,
                src.IsActive,
                src.IsFeatured))
            .ForAllMembers(opt => opt.Ignore());
    }
}
