
namespace Specification.Unit.Testing.Fakers;

public class PersonNameSpecification : SpecificationBase<Person>
{
    private string _name;

    public PersonNameSpecification(string name) => _name = name;

    public override Expression<Func<Person, bool>> ToExpression() => x => x.Name == _name;
}

public class PersonEmailSpecification : SpecificationBase<Person>
{
    private string _email;

    public PersonEmailSpecification(string email) => _email = email;

    public override Expression<Func<Person, bool>> ToExpression() => x => x.Email == _email;
}