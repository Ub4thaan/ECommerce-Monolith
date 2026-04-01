namespace Domain.Specifications;

using System.Linq.Expressions;

internal sealed class OrSpecification<T>(Specification<T> left, Specification<T> right) : Specification<T>
    where T : class
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = left.ToExpression();
        var rightExpression = right.ToExpression();

        var parameter = Expression.Parameter(typeof(T));

        var body = Expression.OrElse(
            new ParameterReplacer(leftExpression.Parameters[0], parameter).Visit(leftExpression.Body),
            new ParameterReplacer(rightExpression.Parameters[0], parameter).Visit(rightExpression.Body));

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}
