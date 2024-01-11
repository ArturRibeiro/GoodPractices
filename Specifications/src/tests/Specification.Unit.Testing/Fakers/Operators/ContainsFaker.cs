namespace Specification.Unit.Testing.Fakers.Operators;

public class ContainsFaker : TheoryData<ContainsSpecification<Person, string>, Person, bool>
{
    public ContainsFaker() =>
        Add(new ContainsSpecification<Person, string>(p => p.Tags, "important"), new Person(), true);
}