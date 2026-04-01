using System.Diagnostics.CodeAnalysis;

namespace Domain.Primitives.Abstractions;

[SuppressMessage("SonarQube", "S4035:Classes implementing \"IEquatable<T>\" should be sealed or implement \"IEqualityComparer<T>\"",
    Justification = "This is an abstract base class for domain entities. Type checking in Equals maintains the equality contract.")]
public abstract class ValueObject : IEquatable<ValueObject>
{
    public static bool operator ==(ValueObject? left, ValueObject? right)
        => left?.Equals(right) ?? right is null;

    public static bool operator !=(ValueObject? left, ValueObject? right)
        => !(left == right);

    public bool Equals(ValueObject? other)
    {
        if (other is null || other.GetType() != GetType())
        {
            return false;
        }

        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject valueObject && Equals(valueObject);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(default(int), HashCode.Combine);
    }

    protected abstract IEnumerable<object> GetAtomicValues();
}
