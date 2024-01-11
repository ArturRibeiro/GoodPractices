namespace Specification.Unit.Testing.Fakers;

public class FakeSpecification : SpecificationBase<bool>
{
    private readonly bool _result;

    public FakeSpecification(bool result) => _result = result;

    public override Expression<Func<bool, bool>> ToExpression() => b => _result;
}