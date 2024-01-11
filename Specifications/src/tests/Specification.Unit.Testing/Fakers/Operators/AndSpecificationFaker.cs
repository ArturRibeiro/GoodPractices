namespace Specification.Unit.Testing.Fakers.Operators;

public class AndSpecificationFaker : TheoryData<FakeSpecification, FakeSpecification, bool>
{
    public AndSpecificationFaker()
    {
        Add(new FakeSpecification(true), new FakeSpecification(true), true);
        Add(new FakeSpecification(true), new FakeSpecification(false), false);
        Add(new FakeSpecification(false), new FakeSpecification(false), false);
    }
}