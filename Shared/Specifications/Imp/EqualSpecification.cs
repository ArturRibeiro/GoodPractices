namespace Shared.Specifications.Imp;

public class EqualSpecification<T> : SpecificationBase<T>
{
    private readonly object _value;
    private readonly Expression<Func<T, object>> _expression;

    public EqualSpecification(Expression<Func<T, object>> expression, object value)
    {
        _value = value;
        _expression = expression;
    }
    public override Expression<Func<T, bool>> ToExpression() => x => _expression.Compile()(x).Equals(_value);
}