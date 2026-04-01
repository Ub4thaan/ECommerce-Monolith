namespace Domain.Primitives.Abstractions;

public abstract record TypedId<T>(T Value) : IEquatable<TypedId<T>> where T : notnull
{
    public override string ToString() => Value.ToString()!;
    public static implicit operator T(TypedId<T> typedId) => typedId.Value;

    public virtual bool Equals(TypedId<T>? other)
    {
        if (other is null)
        {
            return false;
        }

        return EqualityComparer<T>.Default.Equals(Value, other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}