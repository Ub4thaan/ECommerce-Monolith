namespace Infrastructure.Mapping;

using AutoMapper;
using Domain.Entities.Shipments;
using Domain.Primitives;
using Infrastructure.Persistence.Entities;

public sealed class ShipmentMappingProfile : Profile
{
    public ShipmentMappingProfile()
    {
        CreateMap<Shipment, ShipmentDb>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.Value))
            .ForMember(d => d.OrderId, o => o.MapFrom(s => s.OrderId.Value))
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.UpdatedAt, o => o.Ignore())
            .ForMember(d => d.IsDeleted, o => o.Ignore())
            .ForMember(d => d.DeletedAt, o => o.Ignore());

        CreateMap<ShipmentDb, Shipment>()
            .ConstructUsing(src => new Shipment(
                new ShipmentId(src.Id),
                new OrderId(src.OrderId),
                src.ShippingMethod,
                src.TrackingNumber,
                src.Carrier,
                src.Street,
                src.HouseNumber,
                src.PostalCode,
                src.City,
                src.Country,
                src.State,
                src.Status,
                src.ShippedAt,
                src.EstimatedDeliveryDate))
            .ForAllMembers(opt => opt.Ignore());
    }
}
