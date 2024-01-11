namespace Specifications.Imp;

public class OrSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public OrSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
    {
        _left = spec1;
        _right = spec2;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();
        var andExpression = Expression.Or(leftExpression.Body, rightExpression.Body);
        return Expression.Lambda<Func<T , bool>>(andExpression, leftExpression.Parameters.Single());
    }
}