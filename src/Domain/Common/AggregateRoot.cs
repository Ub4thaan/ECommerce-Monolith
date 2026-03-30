using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common;

// Domain/Common/AggregateRoot.cs
using System.Collections.Generic;

public abstract class AggregateRoot<TId>(TId id) : Entity<TId>(id)
    where TId : notnull
{
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    private readonly List<DomainEvent> _domainEvents = [];

    protected void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}