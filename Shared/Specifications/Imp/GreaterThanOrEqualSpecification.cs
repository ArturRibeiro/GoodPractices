namespace Shared.Specifications.Imp;

public class GreaterThanOrEqualSpecification<T> : SpecificationBase<T>
{
    private readonly Expression<Func<T, IComparable>> _expression;
    private readonly IComparable _value;

    public GreaterThanOrEqualSpecification(Expression<Func<T, IComparable>> expression, IComparable value)
    {
        _expression = expression;
        _value = value;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        return entity => _expression.Compile()(entity).CompareTo(_value) >= 0;
    }
}