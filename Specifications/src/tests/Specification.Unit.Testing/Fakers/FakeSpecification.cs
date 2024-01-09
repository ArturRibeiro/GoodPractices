namespace Specification.Unit.Testing.Fakers;

public class FakeSpecification : SpecificationBase<bool>
{
    private readonly bool _result;

    public FakeSpecification(bool result) => _result = result;
    public override bool IsSatisfiedBy(bool candidate) => _result;
}