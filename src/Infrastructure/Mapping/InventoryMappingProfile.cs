namespace Infrastructure.Mapping;

using AutoMapper;
using Domain.Entities.Inventories;
using Domain.Primitives;
using Infrastructure.Persistence.Entities;

public sealed class InventoryMappingProfile : Profile
{
    public InventoryMappingProfile()
    {
        CreateMap<Inventory, InventoryDb>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.Value))
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId.Value))
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.UpdatedAt, o => o.Ignore())
            .ForMember(d => d.IsDeleted, o => o.Ignore())
            .ForMember(d => d.DeletedAt, o => o.Ignore());

        CreateMap<InventoryDb, Inventory>()
            .ConstructUsing(src => new Inventory(
                new InventoryId(src.Id),
                new ProductId(src.ProductId),
                src.Quantity,
                src.ReservedQuantity,
                src.ReorderPoint,
                src.LastRestockDate))
            .ForAllMembers(opt => opt.Ignore());
    }
}
