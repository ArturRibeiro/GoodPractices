namespace Shared.Specifications.Imp;

public class GreaterThanSpecification<T> : SpecificationBase<T>
{
    private readonly Expression<Func<T, IComparable>> _property;
    private readonly object _value;

    public GreaterThanSpecification(Expression<Func<T, IComparable>> property, object value)
    {
        _property = property;
        _value = value;
    }

    public override Expression<Func<T, bool>> ToExpression() => entity => _property.Compile()(entity).CompareTo(_value) > 0;
}