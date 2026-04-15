namespace Infrastructure.Mapping;

using AutoMapper;
using Domain.Primitives;

public sealed class TypedIdMappingProfile : Profile
{
    public TypedIdMappingProfile()
    {
        CreateMap<CategoryId, int>().ConvertUsing(src => src.Value);
        CreateMap<int, CategoryId>().ConvertUsing(src => new CategoryId(src));

        CreateMap<ProductId, int>().ConvertUsing(src => src.Value);
        CreateMap<int, ProductId>().ConvertUsing(src => new ProductId(src));

        CreateMap<OrderId, int>().ConvertUsing(src => src.Value);
        CreateMap<int, OrderId>().ConvertUsing(src => new OrderId(src));

        CreateMap<OrderItemId, int>().ConvertUsing(src => src.Value);
        CreateMap<int, OrderItemId>().ConvertUsing(src => new OrderItemId(src));

        CreateMap<CustomerId, int>().ConvertUsing(src => src.Value);
        CreateMap<int, CustomerId>().ConvertUsing(src => new CustomerId(src));

        CreateMap<PaymentId, int>().ConvertUsing(src => src.Value);
        CreateMap<int, PaymentId>().ConvertUsing(src => new PaymentId(src));

        CreateMap<ShipmentId, int>().ConvertUsing(src => src.Value);
        CreateMap<int, ShipmentId>().ConvertUsing(src => new ShipmentId(src));

        CreateMap<InventoryId, int>().ConvertUsing(src => src.Value);
        CreateMap<int, InventoryId>().ConvertUsing(src => new InventoryId(src));

        CreateMap<CategoryId?, int?>().ConvertUsing((src, _) => src != null ? src.Value : null);
        CreateMap<int?, CategoryId?>().ConvertUsing((src, _) => src.HasValue ? new CategoryId(src.Value) : null);
    }
}
