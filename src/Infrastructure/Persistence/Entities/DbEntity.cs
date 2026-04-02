namespace Infrastructure.Persistence.Entities;

public interface IDatabaseEntity
{
    DateTime CreatedAt { get; set; }

    DateTime? UpdatedAt { get; set; }

    bool IsDeleted { get; set; }

    DateTime? DeletedAt { get; set; }
}

public abstract class DbEntity<TId> : IDatabaseEntity where TId : notnull
{
    public TId Id { get; set; } = default!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }
}
