namespace Specification.Unit.Testing;

public class SpecificationsTests
{
    [Theory(DisplayName = "Operator AndSpecification Is SatisfiedBy")]
    [ClassData(typeof(AndSpecificationFaker))]
    public void AndSpecificationIsSatisfiedBy(FakeSpecification spec1, FakeSpecification spec2, bool expected)
    {
        // Arrange
        var andSpec = spec1.And(spec2);

        // Act
        var result = andSpec.IsSatisfiedBy(expected);

        // Assert
        result.Should().Be(result);
    }

    [Theory(DisplayName = "Operator OrSpecification Is SatisfiedBy")]
    [ClassData(typeof(OrSpecificationFaker))]
    public void OrSpecificationIsSatisfiedBy(FakeSpecification spec1, FakeSpecification spec2, bool expected)
    {
        // Arrange
        var andSpec = spec1.Or(spec2);

        // Act
        var result = andSpec.IsSatisfiedBy(expected);

        // Assert
        result.Should().Be(result);
    }

    [Theory(DisplayName = "Operator NotSpecification Is SatisfiedBy")]
    [ClassData(typeof(NotSpecificationFaker))]
    public void NotSpecificationIsSatisfiedBy(FakeSpecification spec1, bool expected)
    {
        // Arrange
        var andSpec = spec1.Not();

        // Act
        var result = andSpec.IsSatisfiedBy(expected);

        // Assert
        result.Should().Be(result);
    }

    [Theory(DisplayName = "Operator Not Specification With Parameter Is SatisfiedBy")]
    [ClassData(typeof(NotWithParameterFaker))]
    public void NotSpecificationWithParameterIsSatisfiedBy(FakeSpecification spec1, FakeSpecification spec2,
        bool expected)
    {
        // Arrange
        var andSpec = spec1.Not(spec2);

        // Act
        var result = andSpec.IsSatisfiedBy(expected);

        // Assert
        result.Should().Be(result);
    }

    [Theory(DisplayName = "Operator Contains Specification Is SatisfiedBy")]
    [ClassData(typeof(ContainsFaker))]
    //[Fact]
    public void ContainsSpecificationIsSatisfiedBy(ContainsSpecification<Person, string> specification, Person person,
        bool expected)
    {
        // Arrange

        // Act
        var result = specification.IsSatisfiedBy(person);

        // Assert
        result.Should().Be(expected);
    }

    [Fact(DisplayName = "Operator Greater Than Specification Is SatisfiedBy")]
    public void GreaterThanSpecificationIsSatisfiedBy()
    {
        // Arrange
        var greaterThanSpecification = new GreaterThanSpecification<Person>(i => i.Age, (short)10);

        // Act
        var first = Person.Data.All().First(greaterThanSpecification.ToExpression().Compile());

        // Assert
        greaterThanSpecification.IsSatisfiedBy(first).Should().BeTrue();
    }

    [Fact(DisplayName = "Operator Less Than Specification Is SatisfiedBy")]
    public void LessThanSpecificationIsSatisfiedBy()
    {
        // Arrange
        var greaterThanSpecification = new LessThanSpecification<Person>(i => i.Age, (short)11);

        // Act
        var first = Person.Data.All().Single(greaterThanSpecification.ToExpression().Compile());

        // Assert
        greaterThanSpecification.IsSatisfiedBy(first).Should().BeTrue();
    }

    [Fact(DisplayName = "Operator Greater Than Or Equal Specification Is SatisfiedBy")]
    public void GreaterThanOrEqualSpecificationIsSatisfiedBy()
    {
        // Arrange
        var greaterThanOrEqualSpecification = new GreaterThanOrEqualSpecification<Person>(i => i.Age, (short)10);

        // Act
        var list = Person.Data.All().Where(greaterThanOrEqualSpecification.ToExpression().Compile()).ToList();

        // Assert
        list.Should().HaveCount(Person.Data.All().Count);
    }

    [Fact(DisplayName = "Operator Less Than Or Equal Specification Is SatisfiedBy")]
    public void LessThanOrEqualSpecificationIsSatisfiedBy()
    {
        // Arrange
        var lessThanOrEqualSpecification = new LessThanOrEqualSpecification<Person>(i => i.Age, (short)10);

        // Act
        var list = Person.Data.All().Where(lessThanOrEqualSpecification.ToExpression().Compile()).ToList();

        // Assert
        list.Should().HaveCount(1);
    }
}