using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DomainEvents;

public interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<DomainEvent> domainEvents, CancellationToken cancellationToken = default);
}