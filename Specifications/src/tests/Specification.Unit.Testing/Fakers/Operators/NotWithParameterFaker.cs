namespace Specification.Unit.Testing.Fakers.Operators;

public class NotWithParameterFaker : TheoryData<FakeSpecification, FakeSpecification, bool>
{
    public NotWithParameterFaker()
    {
        Add(new FakeSpecification(true), new FakeSpecification(true), true);
        Add(new FakeSpecification(true), new FakeSpecification(false), true);
        Add(new FakeSpecification(false), new FakeSpecification(false), false);
    }
}