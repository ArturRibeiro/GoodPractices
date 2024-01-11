namespace Shared.Specifications.Imp;

public abstract class SpecificationBase<T> : ISpecification<T>
{
    public bool IsSatisfiedBy(T entity)
    {
        var predicate = ToExpression().Compile();
        return predicate(entity);
    }
    
    public ISpecification<T> And(ISpecification<T> other) => new AndSpecification<T>(this, other);
    public ISpecification<T> Or(ISpecification<T> other) => new OrSpecification<T>(this, other);
    public ISpecification<T> Not() => new NotSpecification<T>(this);
    public ISpecification<T> Not(ISpecification<T> other) => other.Not();
    public ISpecification<T> Contains<TValue>(Expression<Func<T, IEnumerable<TValue>>> valueSelector, TValue targetValue) => new ContainsSpecification<T, TValue>(valueSelector, targetValue);
    public abstract Expression<Func<T , bool>> ToExpression();
}