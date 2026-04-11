namespace Infrastructure.Repositories;

using Application.Repositories;
using Application.Repositories.Results;
using Application.Specifications;
using Domain.Entities.Abstractions;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public abstract class Repository<TEntity, TId>(ApplicationDbContext dbContext)
    : IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    protected readonly ApplicationDbContext DbContext = dbContext;
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync([id], cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<TEntity>> FindAsync(
        Specification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {
        return await ApplySpecification(specification)
            .ToListAsync(cancellationToken);
    }

    public async Task<PagedResult<TEntity>> FindPagedAsync(
        Specification<TEntity> specification,
        CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(specification);

        var totalCount = await query.CountAsync(cancellationToken);

        if (specification.IsPagingEnabled)
        {
            query = query
                .Skip(specification.Skip!.Value)
                .Take(specification.Take!.Value);
        }

        var items = await query.ToListAsync(cancellationToken);

        return new PagedResult<TEntity>(
            items,
            specification.IsPagingEnabled ? (specification.Skip!.Value / specification.Take!.Value) + 1 : 1,
            specification.Take ?? totalCount,
            totalCount);
    }

    public void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        DbSet.AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
    }

    private IQueryable<TEntity> ApplySpecification(Specification<TEntity> specification)
    {
        var query = DbSet.Where(specification.ToExpression());

        if (specification.OrderByExpression is not null)
        {
            query = query.OrderBy(specification.OrderByExpression);
        }
        else if (specification.OrderByDescendingExpression is not null)
        {
            query = query.OrderByDescending(specification.OrderByDescendingExpression);
        }

        return query;
    }
}