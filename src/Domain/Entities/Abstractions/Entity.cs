using System.Diagnostics.CodeAnalysis;

namespace Domain.Entities.Abstractions;

[SuppressMessage("SonarQube", "S4035:Classes implementing \"IEquatable<T>\" should be sealed or implement \"IEqualityComparer<T>\"",
    Justification = "This is an abstract base class for domain entities. Type checking in Equals maintains the equality contract.")]
public abstract class Entity<TId>(TId id) : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; private init; } = id;

    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        if (left is null)
        {
            return right is null;
        }

        return left.Equals(right);
    }

    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }

    public bool Equals(Entity<TId>? other)
    {
        if (other is null || other.GetType() != GetType())
        {
            return false;
        }

        return EqualityComparer<TId>.Default.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Equals(entity);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
