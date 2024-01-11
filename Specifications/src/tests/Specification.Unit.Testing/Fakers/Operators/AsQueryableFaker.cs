using Specifications;

namespace Specification.Unit.Testing.Fakers.Operators;

public class PredicateFirstFaker : TheoryData<ISpecification<Person>, List<Person>, string>
{
    public PredicateFirstFaker()
    {
        var persons = new List<Person>()
        {
            new() { Name = "Artur", Email = "artur@r.com", Age = 43},
            new() { Name = "Ribeiro", Email = "ribeiro@r.com", Age = 35 },
            new() { Name = "Artur Ribeiro", Email = "artur.ribeiro@r.com", Age = 25 },
            new() { Name = "John Wick", Email = "john.wick@r.com", Age = 55 }
        };

        Add(new PersonNameSpecification("Artur").And(new PersonEmailSpecification("artur@r.com")), persons, "Artur");
        Add(new PersonNameSpecification("Ribeiro").And(new PersonEmailSpecification("ribeiro@r.com")), persons, "Ribeiro");
        Add(new PersonNameSpecification("Ribeiro").And(new PersonEmailSpecification("ribeiro@r.com")), persons, "Ribeiro");
        
        Add(new PersonNameSpecification("Artur Ribeiro")
            .Not(new PersonNameSpecification("Ribeiro")
                .And(new PersonEmailSpecification("ribeiro@r.com"))), persons, "Artur");
        
        Add(new EqualSpecification<Person>(p => p.Name, "John Wick"), persons, "John Wick");


        var johnWick = new EqualSpecification<Person>(p => p.Name, "John Wick");
        var ribeiro = new EqualSpecification<Person>(p => p.Name, "Ribeiro");
        var email = new EqualSpecification<Person>(p => p.Email, "ribeiro@r.com");
        var arturRibeiro = new EqualSpecification<Person>(p => p.Name, "Artur Ribeiro");
        
        var spec = johnWick.Not(ribeiro.And(email)).And(arturRibeiro);

        Add(spec, persons, "Artur Ribeiro");
    }
}

public class PredicateListFaker : TheoryData<ISpecification<Person>, List<Person>, Person>
{
    public PredicateListFaker()
    {
        var lessThan18 = new LessThanSpecification<Person>(x => x.Age, (short)18);
        var greaterThan18 = new GreaterThanSpecification<Person>(x => x.Age, (short)18);
        var email = new EqualSpecification<Person>(x => x.Email, "Winston.Churchill@domain.com");
        var name = new EqualSpecification<Person>(x => x.Name, "Winston Churchill");
        var specification = greaterThan18.And(email.And(name)).Not(lessThan18);
        
        Add(specification, Person.Data.All(), Person.Data.AmeliaEarhart );
    }
}