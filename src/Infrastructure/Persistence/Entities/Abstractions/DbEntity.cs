namespace Infrastructure.Persistence.Entities.Abstractions;

public abstract class Entity<TId> : IDbEntity where TId : notnull
{
    public TId Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
