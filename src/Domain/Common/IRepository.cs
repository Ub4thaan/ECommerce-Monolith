using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common;

public interface IRepository<TAggregate, in TId>
    where TAggregate : AggregateRoot<TId>
    where TId : notnull
{
    Task<TAggregate?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);

    Task AddAsync(TAggregate aggregate, CancellationToken cancellationToken = default);

    void Update(TAggregate aggregate);           // Non async perché EF Core tracka già l'entità
    void Remove(TAggregate aggregate);

    Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default);
}