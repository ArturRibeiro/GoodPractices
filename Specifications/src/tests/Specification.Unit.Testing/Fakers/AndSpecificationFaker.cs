namespace Specification.Unit.Testing.Fakers;

public class AndSpecificationFaker : TheoryData<FakeSpecification, FakeSpecification, bool>
{
    public AndSpecificationFaker()
    {
        Add(new FakeSpecification(true), new FakeSpecification(true), true);
        Add(new FakeSpecification(true), new FakeSpecification(false), false);
        Add(new FakeSpecification(false), new FakeSpecification(false), false);
    }
}

public class OrSpecificationFaker : TheoryData<FakeSpecification, FakeSpecification, bool>
{
    public OrSpecificationFaker()
    {
        Add(new FakeSpecification(true), new FakeSpecification(true), true);
        Add(new FakeSpecification(true), new FakeSpecification(false), true);
        Add(new FakeSpecification(false), new FakeSpecification(false), false);
    }
}

public class NotSpecificationFaker : TheoryData<FakeSpecification, bool>
{
    public NotSpecificationFaker()
    {
        Add(new FakeSpecification(true), false);
        Add(new FakeSpecification(false), true);
    }
}

public class NotWithParameterFaker : TheoryData<FakeSpecification, FakeSpecification, bool>
{
    public NotWithParameterFaker()
    {
        Add(new FakeSpecification(true), new FakeSpecification(true), true);
        Add(new FakeSpecification(true), new FakeSpecification(false), true);
        Add(new FakeSpecification(false), new FakeSpecification(false), false);
    }
}

public class ContainsFaker : TheoryData<ContainsSpecification<Person, string>, Person, bool>
{
    public ContainsFaker() => Add(new ContainsSpecification<Person, string>(p => p.Tags, "important"), new Person(), true);
}