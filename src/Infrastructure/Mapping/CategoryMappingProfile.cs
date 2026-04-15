namespace Infrastructure.Mapping;

using AutoMapper;
using Domain.Entities.Catalogs;
using Domain.Primitives;
using Infrastructure.Persistence.Entities;

public sealed class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CategoryDb>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.Value))
            .ForMember(d => d.ParentCategoryId, o => o.MapFrom(s => s.ParentCategoryId != null ? (int?)s.ParentCategoryId.Value : null))
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.UpdatedAt, o => o.Ignore())
            .ForMember(d => d.IsDeleted, o => o.Ignore())
            .ForMember(d => d.DeletedAt, o => o.Ignore());

        CreateMap<CategoryDb, Category>()
            .ConstructUsing(src => new Category(
                new CategoryId(src.Id),
                src.Name,
                src.Description,
                src.Slug,
                src.ParentCategoryId.HasValue ? new CategoryId(src.ParentCategoryId.Value) : null,
                src.IsActive,
                src.IsFeatured))
            .ForAllMembers(opt => opt.Ignore());
    }
}
