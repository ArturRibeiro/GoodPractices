namespace Specifications.Imp;

public class AndSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();
        var alias = leftExpression.Parameters[0];
        var andExpression = Expression.AndAlso(leftExpression.Body, Expression.Invoke(rightExpression, alias));
        return Expression.Lambda<Func<T , bool>>(andExpression, alias);
    }
}