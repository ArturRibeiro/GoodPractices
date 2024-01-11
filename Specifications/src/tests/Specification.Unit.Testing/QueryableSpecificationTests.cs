namespace Specification.Unit.Testing;

public class QueryableSpecificationTests
{
    [Theory(DisplayName = "Queryable First Success")]
    [ClassData(typeof(PredicateFirstFaker))]
    public void QueryableFirstSuccess(ISpecification<Person> specification, List<Person> persons, string expected)
    {
        // Arrange
        // Act
        var result = persons.AsQueryable().First(specification.ToExpression());

        // Assert
        result.Should().NotBeNull();
        specification.IsSatisfiedBy(result).Should().BeTrue();
        result.Name.Should().Be(expected);
    }
    
    [Theory(DisplayName = "Queryable List Success")]
    [ClassData(typeof(PredicateListFaker))]
    public void QueryableListSuccess(ISpecification<Person> specification, List<Person> persons, Person expectedPerson)
    {
        // Arrange
        // Act
        var result = persons.AsQueryable().Where(specification.ToExpression()).ToList();

        // Assert
        result.Should().NotBeNull();
        result[0].Should().Be(expectedPerson);
        specification.IsSatisfiedBy(expectedPerson).Should().BeTrue();
        result[0].Name.Should().Be(expectedPerson.Name);
        result[0].Email.Should().Be(expectedPerson.Email);
    }
}