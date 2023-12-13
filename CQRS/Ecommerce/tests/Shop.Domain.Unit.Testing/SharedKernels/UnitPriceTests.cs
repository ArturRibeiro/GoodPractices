namespace Shop.Domain.Unit.Testing.SharedKernels;

public class UnitPriceTests
{
    [Fact]
    public void Create_ValidValue_ShouldCreateInstance()
    {
        // Arrange
        decimal validValue = 42.56m;

        // Act
        UnitPrice unitPrice = validValue;

        // Assert
        unitPrice.Should().NotBeNull();
        unitPrice.ValueInCents.Should().Be(4256);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-42.56)]
    public void Create_InvalidValue_ShouldThrowException(decimal invalidValue)
    {
        // Assert
        Action action = () => { UnitPrice unitPrice = invalidValue; };
        action.Should().Throw<ArgumentException>().WithMessage("O valor da unidade de preço não pode ser negativo.");
    }

    [Fact]
    public void ToString_FormattingShouldBeCorrect()
    {
        // Arrange
        UnitPrice unitPrice = 42.56m;

        // Act
        string result = unitPrice.ToString();

        // Assert
        result.Should().Be("R$ 42,56");
    }

    [Fact]
    public void Equals_TwoEqualPrices_ShouldReturnTrue()
    {
        // Arrange
        UnitPrice price1 = 42.56m;
        UnitPrice price2 = 42.56m;

        // Act
        bool result = price1.Equals(price2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_TwoDifferentPrices_ShouldReturnFalse()
    {
        // Arrange
        UnitPrice price1 = 42.56m;
        UnitPrice price2 = 30.00m;

        // Act
        bool result = price1.Equals(price2);

        // Assert
        result.Should().BeFalse();
    }
}