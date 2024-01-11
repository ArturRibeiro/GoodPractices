namespace Shared.Specifications.Imp;

public class OrSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public OrSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();
        var andExpression = Expression.Or(leftExpression.Body, rightExpression.Body);
        return Expression.Lambda<Func<T , bool>>(andExpression, leftExpression.Parameters.Single());
    }
}