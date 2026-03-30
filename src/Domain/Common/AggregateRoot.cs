using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common;

// Domain/Common/AggregateRoot.cs
using System.Collections.Generic;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    private readonly List<DomainEvent> _domainEvents = new();

    protected AggregateRoot(TId id) : base(id)
    {
    }

    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}