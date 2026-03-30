using Domain.Common;
using Infrastructure.DomainEvents;
using Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork(ApplicationDbContext context, IDomainEventDispatcher dispatcher) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;
    private readonly IDomainEventDispatcher _dispatcher = dispatcher;
    private bool _disposed;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        // 1. Get all aggregates with events
        var aggregatesWithEvents = _context.ChangeTracker
            .Entries<AggregateRoot<Guid>>()
            .Where(e => e.Entity.DomainEvents.Any())
            .Select(e => e.Entity)
            .ToList();

        // 2. Collect all events to dispatch after the commit
        var domainEvents = aggregatesWithEvents
            .SelectMany(x => x.DomainEvents)
            .ToList();

        // 3. Clear domain events from aggregates (after collecting them)
        aggregatesWithEvents.ForEach(x => x.ClearDomainEvents());

        // 4. Save changes to the database (commit)
        await _context.SaveChangesAsync(cancellationToken);

        // 5. Dispatch domain events after the commit
        if (domainEvents.Any())
            await _dispatcher.DispatchAsync(domainEvents, cancellationToken);

        return true;
    }

    // ========== DISPOSAL PATTERN ==========
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context?.Dispose();        // Rilascio il DbContext
            }

            _disposed = true;
        }
    }

    // Opzionale: async disposal (se usi IAsyncDisposable in futuro)
    // public async ValueTask DisposeAsync()
    // {
    //     await _context.DisposeAsync();
    // }
}