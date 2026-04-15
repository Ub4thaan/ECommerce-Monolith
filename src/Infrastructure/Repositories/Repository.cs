namespace Infrastructure.Repositories;

using Application.Repositories;
using Application.Repositories.Results;
using Application.Specifications;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.Primitives.Abstractions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public abstract class Repository<TDomainEntity, TDbEntity, TDomainId>(
    ApplicationDbContext dbContext,
    IMapper mapper)
    : IRepository<TDomainEntity, TDomainId>
    where TDomainEntity : Domain.Entities.Abstractions.Entity<TDomainId>
    where TDbEntity : Entity<int>
    where TDomainId : notnull
{
    protected readonly ApplicationDbContext DbContext = dbContext;
    protected readonly DbSet<TDbEntity> DbSet = dbContext.Set<TDbEntity>();
    protected readonly IMapper Mapper = mapper;

    public async Task<TDomainEntity?> GetByIdAsync(TDomainId id, CancellationToken cancellationToken = default)
    {
        var dbId = ConvertId(id);
        var dbEntity = await DbSet
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == dbId, cancellationToken);
        return dbEntity is null ? null : Mapper.Map<TDomainEntity>(dbEntity);
    }

    public async Task<IReadOnlyList<TDomainEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var dbEntities = await DbSet.AsNoTracking().ToListAsync(cancellationToken);
        return Mapper.Map<List<TDomainEntity>>(dbEntities).AsReadOnly();
    }

    public async Task<IReadOnlyList<TDomainEntity>> FindAsync(
        Specification<TDomainEntity> specification,
        CancellationToken cancellationToken = default)
    {
        var dbEntities = await ApplySpecification(specification)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return Mapper.Map<List<TDomainEntity>>(dbEntities).AsReadOnly();
    }

    public async Task<PagedResult<TDomainEntity>> FindPagedAsync(
        Specification<TDomainEntity> specification,
        CancellationToken cancellationToken = default)
    {
        var query = ApplySpecification(specification).AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);

        if (specification.IsPagingEnabled)
        {
            query = query
                .Skip(specification.Skip!.Value)
                .Take(specification.Take!.Value);
        }

        var dbEntities = await query.ToListAsync(cancellationToken);
        var items = Mapper.Map<List<TDomainEntity>>(dbEntities).AsReadOnly();

        return new PagedResult<TDomainEntity>(
            items,
            specification.IsPagingEnabled ? (specification.Skip!.Value / specification.Take!.Value) + 1 : 1,
            specification.Take ?? totalCount,
            totalCount);
    }

    public void Add(TDomainEntity entity)
    {
        var dbEntity = Mapper.Map<TDbEntity>(entity);
        DbSet.Add(dbEntity);
    }

    public void AddRange(IEnumerable<TDomainEntity> entities)
    {
        var dbEntities = entities.Select(Mapper.Map<TDomainEntity, TDbEntity>).ToList();
        DbSet.AddRange(dbEntities);
    }

    public void Update(TDomainEntity entity)
    {
        var dbEntity = Mapper.Map<TDbEntity>(entity);
        DbSet.Update(dbEntity);

        var entry = DbContext.Entry(dbEntity);
        entry.Property(nameof(IDbEntity.CreatedAt)).IsModified = false;
        entry.Property(nameof(IDbEntity.IsDeleted)).IsModified = false;
        entry.Property(nameof(IDbEntity.DeletedAt)).IsModified = false;
    }

    public void Remove(TDomainEntity entity)
    {
        var dbEntity = Mapper.Map<TDbEntity>(entity);
        DbSet.Remove(dbEntity);
    }

    public void RemoveRange(IEnumerable<TDomainEntity> entities)
    {
        var dbEntities = entities.Select(Mapper.Map<TDomainEntity, TDbEntity>).ToList();
        DbSet.RemoveRange(dbEntities);
    }

    private IQueryable<TDbEntity> ApplySpecification(Specification<TDomainEntity> specification)
    {
        var dbFilter = Mapper.MapExpression<Expression<Func<TDbEntity, bool>>>(specification.ToExpression());
        var query = DbSet.Where(dbFilter);

        if (specification.OrderByExpression is not null)
        {
            var dbOrderBy = Mapper.MapExpression<Expression<Func<TDbEntity, object>>>(specification.OrderByExpression);
            query = query.OrderBy(dbOrderBy);
        }
        else if (specification.OrderByDescendingExpression is not null)
        {
            var dbOrderByDesc = Mapper.MapExpression<Expression<Func<TDbEntity, object>>>(specification.OrderByDescendingExpression);
            query = query.OrderByDescending(dbOrderByDesc);
        }

        return query;
    }

    private static int ConvertId(TDomainId domainId) => domainId is TypedId<int> typedId
        ? typedId.Value
        : throw new InvalidOperationException($"Cannot convert {typeof(TDomainId).Name} to a database identifier.");
}