namespace Shared.Specifications.Imp;

public class LessThanSpecification<T> : SpecificationBase<T>
{
    private readonly Expression<Func<T, IComparable>> _property;
    private readonly IComparable _value;

    public LessThanSpecification(Expression<Func<T, IComparable>> property, IComparable value)
    {
        _property = property;
        _value = value;
    }

    public override Expression<Func<T, bool>> ToExpression() => entity => _property.Compile()(entity).CompareTo(_value) < 0;
}