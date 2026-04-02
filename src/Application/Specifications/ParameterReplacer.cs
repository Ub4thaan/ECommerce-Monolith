namespace Application.Specifications;

using System.Linq.Expressions;

internal sealed class ParameterReplacer(
    ParameterExpression oldParameter,
    ParameterExpression newParameter) : ExpressionVisitor
{
    protected override Expression VisitParameter(ParameterExpression node)
    {
        return ReferenceEquals(node, oldParameter) ? newParameter : base.VisitParameter(node);
    }
}
