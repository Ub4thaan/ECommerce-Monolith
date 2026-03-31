using Domain.Common;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories;

public class RepositoryBase<TAggregate, TId>(ApplicationDbContext context) : IRepository<TAggregate, TId>
    where TAggregate : AggregateRoot<TId>
    where TId : notnull
{
    protected readonly ApplicationDbContext _context = context;
    protected readonly DbSet<TAggregate> _dbSet = context.Set<TAggregate>();

    public virtual async Task<TAggregate?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public virtual async Task AddAsync(TAggregate aggregate, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(aggregate, cancellationToken);
    }

    public virtual void Update(TAggregate aggregate)
    {
        _dbSet.Update(aggregate);
    }

    public virtual void Remove(TAggregate aggregate)
    {
        _dbSet.Remove(aggregate);
    }

    public virtual async Task<bool> ExistsAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AnyAsync(e => e.Id.Equals(id), cancellationToken);
    }
}