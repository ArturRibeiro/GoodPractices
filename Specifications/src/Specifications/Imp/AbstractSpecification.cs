namespace Specifications.Imp;

public abstract class SpecificationBase<T> : ISpecification<T>
{
    public abstract bool IsSatisfiedBy(T candidate);
    public ISpecification<T> And(ISpecification<T> other) => new AndSpecification<T>(this, other);
    public ISpecification<T> Or(ISpecification<T> other) => new OrSpecification<T>(this, other);
    public ISpecification<T> Not() => new NotSpecification<T>(this);
    public ISpecification<T> Not(ISpecification<T> other) => other.Not();

    public ISpecification<T> Contains<TValue>(Func<T, IEnumerable<TValue>> valueSelector, TValue targetValue) => new ContainsSpecification<T, TValue>(valueSelector, targetValue);
}