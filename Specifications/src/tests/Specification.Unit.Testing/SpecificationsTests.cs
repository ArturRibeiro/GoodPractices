namespace Specification.Unit.Testing;

public class AndSpecificationTests
{
    [Theory]
    [ClassData(typeof(AndSpecificationFaker))]
    public void AndIsSatisfiedBy(FakeSpecification spec1, FakeSpecification spec2, bool expected)
    {
        // Arrange
        var andSpec = spec1.And(spec2);

        // Act
        var result = andSpec.IsSatisfiedBy(expected);

        // Assert
        result.Should().Be(result);
    }

    [Theory]
    [ClassData(typeof(OrSpecificationFaker))]
    public void OrIsSatisfiedBy(FakeSpecification spec1, FakeSpecification spec2, bool expected)
    {
        // Arrange
        var andSpec = spec1.Or(spec2);

        // Act
        var result = andSpec.IsSatisfiedBy(expected);

        // Assert
        result.Should().Be(result);
    }
    
    [Theory]
    [ClassData(typeof(NotSpecificationFaker))]
    public void NotIsSatisfiedBy(FakeSpecification spec1, bool expected)
    {
        // Arrange
        var andSpec = spec1.Not();

        // Act
        var result = andSpec.IsSatisfiedBy(expected);

        // Assert
        result.Should().Be(result);
    }
    
    [Theory]
    [ClassData(typeof(NotWithParameterFaker))]
    public void NotWithParameterIsSatisfiedBy(FakeSpecification spec1, FakeSpecification spec2, bool expected)
    {
        // Arrange
        var andSpec = spec1.Not(spec2);

        // Act
        var result = andSpec.IsSatisfiedBy(expected);

        // Assert
        result.Should().Be(result);
    }
    
    [Theory]
    [ClassData(typeof(ContainsFaker))]
    //[Fact]
    public void ContainsIsSatisfiedBy(ContainsSpecification<Person, string> specification, Person person, bool expected)
    {
        // Arrange

        // Act
        var result = specification.IsSatisfiedBy(person);

        // Assert
        result.Should().Be(expected);
    }
}

public class Person
{
    public Person() => this.Tags = new[] { "important", "important1", "important2" };
    public IEnumerable<string> Tags { get; set; }
}