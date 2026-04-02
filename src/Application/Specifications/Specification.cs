namespace Application.Specifications;

using System.Linq.Expressions;

public abstract class Specification<T>
    where T : class
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public bool IsSatisfiedBy(T entity)
    {
        return ToExpression().Compile().Invoke(entity);
    }

    public Specification<T> And(Specification<T> other)
    {
        return new AndSpecification<T>(this, other);
    }

    public Specification<T> Or(Specification<T> other)
    {
        return new OrSpecification<T>(this, other);
    }

    public Specification<T> Not()
    {
        return new NotSpecification<T>(this);
    }

    public static Specification<T> operator &(Specification<T> left, Specification<T> right)
    {
        return left.And(right);
    }

    public static Specification<T> operator |(Specification<T> left, Specification<T> right)
    {
        return left.Or(right);
    }

    public static Specification<T> operator !(Specification<T> specification)
    {
        return specification.Not();
    }

    public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
    {
        return specification.ToExpression();
    }
}
