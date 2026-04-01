namespace Domain.Specifications;

using System.Linq.Expressions;

internal sealed class NotSpecification<T>(Specification<T> inner) : Specification<T>
    where T : class
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var expression = inner.ToExpression();

        var parameter = Expression.Parameter(typeof(T));

        var body = Expression.Not(
            new ParameterReplacer(expression.Parameters[0], parameter).Visit(expression.Body));

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}
