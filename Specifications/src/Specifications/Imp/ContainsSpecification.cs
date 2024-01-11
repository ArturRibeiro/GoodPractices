namespace Specifications.Imp;

public class ContainsSpecification<T, TValue> : SpecificationBase<T>
{
    private readonly Expression<Func<T, IEnumerable<TValue>>> _valueSelector;
    private readonly TValue _targetValue;

    public ContainsSpecification(Expression<Func<T, IEnumerable<TValue>>> valueSelector, TValue targetValue)
    {
        _valueSelector = valueSelector ?? throw new ArgumentNullException(nameof(valueSelector));
        _targetValue = targetValue;
    }
    
    public override Expression<Func<T, bool>> ToExpression()
    {
        ParameterExpression parameter = _valueSelector.Parameters[0];
        Expression propertyAccess = _valueSelector.Body;
        MethodInfo containsMethod = typeof(Enumerable)
            .GetMethods()
            .Single(m => m.Name == "Contains" && m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(TValue));

        MethodCallExpression containsCall = Expression.Call(containsMethod, propertyAccess, Expression.Constant(_targetValue));

        return Expression.Lambda<Func<T, bool>>(containsCall, parameter);
    }
}