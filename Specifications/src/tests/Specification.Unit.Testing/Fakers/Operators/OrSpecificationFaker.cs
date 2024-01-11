namespace Specification.Unit.Testing.Fakers.Operators;

public class OrSpecificationFaker : TheoryData<FakeSpecification, FakeSpecification, bool>
{
    public OrSpecificationFaker()
    {
        Add(new FakeSpecification(true), new FakeSpecification(true), true);
        Add(new FakeSpecification(true), new FakeSpecification(false), true);
        Add(new FakeSpecification(false), new FakeSpecification(false), false);
    }
}