namespace Application.Repositories;

using Application.Repositories.Results;
using Application.Specifications;
using Domain.Entities.Abstractions;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TId : notnull
{
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TEntity>> FindAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);
    Task<PagedResult<TEntity>> FindPagedAsync(Specification<TEntity> specification, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void RemoveRange(IEnumerable<TEntity> entities);
}