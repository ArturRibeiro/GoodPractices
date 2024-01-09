namespace Specifications.Imp;

public class NotSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _spec;

    public NotSpecification(ISpecification<T> spec) => _spec = spec ?? throw new ArgumentNullException(nameof(spec));

    public override bool IsSatisfiedBy(T candidate) => !_spec.IsSatisfiedBy(candidate);
}