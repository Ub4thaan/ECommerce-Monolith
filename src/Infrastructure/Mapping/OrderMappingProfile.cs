namespace Infrastructure.Mapping;

using AutoMapper;
using Domain.Entities.Orders;
using Domain.Primitives;
using Infrastructure.Persistence.Entities;

public sealed class OrderMappingProfile : Profile
{
    public OrderMappingProfile()
    {
        CreateMap<Order, OrderDb>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.Value))
            .ForMember(d => d.CustomerId, o => o.MapFrom(s => s.CustomerId.Value))
            .ForMember(d => d.OrderItems, o => o.MapFrom(s => s.OrderItems))
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.UpdatedAt, o => o.Ignore())
            .ForMember(d => d.IsDeleted, o => o.Ignore())
            .ForMember(d => d.DeletedAt, o => o.Ignore());

        CreateMap<OrderDb, Order>()
            .ConstructUsing((src, ctx) => new Order(
                new OrderId(src.Id),
                src.OrderNumber,
                new CustomerId(src.CustomerId),
                src.BillingStreet,
                src.BillingHouseNumber,
                src.BillingPostalCode,
                src.BillingCity,
                src.BillingCountry,
                src.BillingState,
                src.ShipmentStreet,
                src.ShipmentHouseNumber,
                src.ShipmentPostalCode,
                src.ShipmentCity,
                src.ShipmentCountry,
                src.ShipmentState,
                src.OrderStatus,
                src.PaymentStatus,
                src.ShipmentStatus,
                src.SubtotalAmount,
                src.TaxAmount,
                src.ShipmentAmount,
                src.TotalAmount,
                src.OrderItems?.Select(oi => ctx.Mapper.Map<OrderItem>(oi))))
            .ForAllMembers(opt => opt.Ignore());

        CreateMap<OrderItem, OrderItemDb>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.Value))
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId.Value))
            .ForMember(d => d.OrderId, o => o.Ignore())
            .ForMember(d => d.Order, o => o.Ignore())
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.UpdatedAt, o => o.Ignore())
            .ForMember(d => d.IsDeleted, o => o.Ignore())
            .ForMember(d => d.DeletedAt, o => o.Ignore());

        CreateMap<OrderItemDb, OrderItem>()
            .ConstructUsing(src => new OrderItem(
                new OrderItemId(src.Id),
                new ProductId(src.ProductId),
                src.ProductName,
                src.Quantity,
                src.UnitPrice,
                src.DiscountAmount,
                src.TotalPrice))
            .ForAllMembers(opt => opt.Ignore());
    }
}
