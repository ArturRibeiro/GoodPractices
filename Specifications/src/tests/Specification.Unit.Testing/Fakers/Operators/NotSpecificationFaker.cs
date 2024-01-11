namespace Specification.Unit.Testing.Fakers.Operators;

public class NotSpecificationFaker : TheoryData<FakeSpecification, bool>
{
    public NotSpecificationFaker()
    {
        Add(new FakeSpecification(true), false);
        Add(new FakeSpecification(false), true);
    }
}