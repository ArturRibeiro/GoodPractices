namespace Specifications.Imp;

public class ContainsSpecification<T, TValue> : SpecificationBase<T>
{
    private readonly Func<T, IEnumerable<TValue>> _valueSelector;
    private readonly TValue _targetValue;

    public ContainsSpecification(Func<T, IEnumerable<TValue>> valueSelector, TValue targetValue)
    {
        _valueSelector = valueSelector ?? throw new ArgumentNullException(nameof(valueSelector));
        _targetValue = targetValue;
    }

    public override bool IsSatisfiedBy(T candidate)
    {
        var values = _valueSelector(candidate);
        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        return values is not null && values.Contains(_targetValue);
    }
}