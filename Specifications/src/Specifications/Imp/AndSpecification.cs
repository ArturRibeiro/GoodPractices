namespace Specifications.Imp;

public class AndSpecification<T> : SpecificationBase<T>
{
    private readonly ISpecification<T> _specLeft;
    private readonly ISpecification<T> _specRight;

    public AndSpecification(ISpecification<T> specLeft, ISpecification<T> specRight)
    {
        _specLeft = specLeft;
        _specRight = specRight;
    }

    public override bool IsSatisfiedBy(T candidate)
    {
        var result = _specLeft.IsSatisfiedBy(candidate) && _specRight.IsSatisfiedBy(candidate);
        return result;
    }
}