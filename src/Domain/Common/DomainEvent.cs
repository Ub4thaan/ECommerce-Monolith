using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Domain.Common;


public abstract record DomainEvent : INotification
{
    public DateTime OccurredOn { get; init; } = DateTime.UtcNow;
    public Guid Id { get; init; } = Guid.NewGuid();
}