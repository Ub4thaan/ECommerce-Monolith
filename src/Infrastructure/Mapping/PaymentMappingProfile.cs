namespace Infrastructure.Mapping;

using AutoMapper;
using Domain.Entities.Payments;
using Domain.Primitives;
using Infrastructure.Persistence.Entities;

public sealed class PaymentMappingProfile : Profile
{
    public PaymentMappingProfile()
    {
        CreateMap<Payment, PaymentDb>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.Value))
            .ForMember(d => d.OrderId, o => o.MapFrom(s => s.OrderId.Value))
            .ForMember(d => d.CreatedAt, o => o.Ignore())
            .ForMember(d => d.UpdatedAt, o => o.Ignore())
            .ForMember(d => d.IsDeleted, o => o.Ignore())
            .ForMember(d => d.DeletedAt, o => o.Ignore());

        CreateMap<PaymentDb, Payment>()
            .ConstructUsing(src => new Payment(
                new PaymentId(src.Id),
                new OrderId(src.OrderId),
                src.PaymentMethod,
                src.Status,
                src.TransactionId,
                src.Amount,
                src.CurrencyCode,
                src.CurrencySymbol,
                src.PaymentDate))
            .ForAllMembers(opt => opt.Ignore());
    }
}
