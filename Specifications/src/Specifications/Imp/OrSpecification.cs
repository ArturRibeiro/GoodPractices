namespace Specifications.Imp;

public class OrSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _spec1;
    private readonly ISpecification<T> _spec2;

    public OrSpecification(ISpecification<T> spec1, ISpecification<T> spec2)
    {
        _spec1 = spec1 ?? throw new ArgumentNullException(nameof(spec1));
        _spec2 = spec2 ?? throw new ArgumentNullException(nameof(spec2));
    }

    public override bool IsSatisfiedBy(T candidate)
    {
        return _spec1.IsSatisfiedBy(candidate) || _spec2.IsSatisfiedBy(candidate);
    }
}