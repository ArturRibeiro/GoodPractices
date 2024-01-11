namespace Shared.Specifications.Imp;

public class NotSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _specification;

    public NotSpecification(ISpecification<T> spec) => _specification = spec;


    public override Expression<Func<T, bool>> ToExpression()
    {
        var expression = _specification.ToExpression();
        var notExpression = Expression.Not(expression.Body);

        return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
    }
}