namespace Shared.Specifications.Imp;

public class ContainsSpecification<T, TValue> : SpecificationBase<T>
{
    private readonly Expression<Func<T, IEnumerable<TValue>>> _expression;
    private readonly TValue _value;
    private const string Contains = "Contains";

    public ContainsSpecification(Expression<Func<T, IEnumerable<TValue>>> expression, TValue value)
    {
        _expression =  expression;
        _value = value;
        _value = value;
    }
    
    public override Expression<Func<T, bool>> ToExpression()
    {
        ParameterExpression parameter = _expression.Parameters[0];
        Expression propertyAccess = _expression.Body;
        MethodInfo containsMethod = typeof(Enumerable)
            .GetMethods()
            .Single(m => m.Name == Contains && m.GetParameters().Length == 2)
            .MakeGenericMethod(typeof(TValue));

        MethodCallExpression containsCall = Expression.Call(containsMethod, propertyAccess, Expression.Constant(_value));

        return Expression.Lambda<Func<T, bool>>(containsCall, parameter);
    }
}