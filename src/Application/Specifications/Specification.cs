namespace Application.Specifications;

using System.Linq.Expressions;

public abstract class Specification<T>
    where T : class
{
    public Expression<Func<T, object>>? OrderByExpression { get; private set; }
    public Expression<Func<T, object>>? OrderByDescendingExpression { get; private set; }
    public int? Skip { get; private set; }
    public int? Take { get; private set; }
    public bool IsPagingEnabled => Skip.HasValue && Take.HasValue;

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

    protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderByExpression = orderByExpression;
        OrderByDescendingExpression = null;
    }

    protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
    {
        OrderByDescendingExpression = orderByDescendingExpression;
        OrderByExpression = null;
    }

    protected void ApplyPaging(int pageNumber, int pageSize)
    {
        Skip = (pageNumber - 1) * pageSize;
        Take = pageSize;
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
