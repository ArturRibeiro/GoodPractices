using FluentAssertions;
using Pattern.Functional.Programming.Extensions;

namespace Pattern.Functional.Programming.Unit.Testing
{
    public class EitherTests
    {
        [Theory]
        [InlineData(10, 0, 0)]
        public void TryDivideByZeroFailed(int v1, int v2, int expected)
        {
            // Assert
            Func<int, int, Either<Exception, int>> Divide = (v1, v2) => Try<int>.Cath(() => v1 / v2);
            // Act
            
            var result = Divide(v1, v2);

            // Assert's
            result.Match(left =>
            {
                left.Should().BeOfType<DivideByZeroException>();
                return 0;
            }, right => right).Should().Be(expected);
        }
        
        [Theory]
        [InlineData(10, 2, 5)]
        public void TryDivideByValueSuccess(int v1, int v2, int expected)
        {
            // Assert
            Func<int, int, Either<Exception, int>> Divide = (v1, v2) => Try<int>.Cath(() => v1 / v2);
            
            // Act
            var result = Divide(v1, v2).Match(left => 1, right => right);

            // Assert's
            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 3)]
        [InlineData(1, 2, 3, 4, 12)]
        [InlineData(24, 2, 58, 12, 141)]
        public void BindSuccess(int v1, int v2, int v3, int v4, int expected)
        {
            // Assert
            Func<int, Either<Exception, int>> Sum = i => Try<int>.Cath(() => i);
            Func<int, Either<Exception, double>> Subtraction = i => Try<double>.Cath(() => i - 2);
            Func<decimal, Either<Exception, decimal>> Division = arg => Try<decimal>.Cath(() => arg / 2);
            Func<int, Either<Exception, int>> Multiplication = arg => Try<int>.Cath(() => arg * 3);
            
            // Act
            var result = Sum(v1 + v2 + v3 + v4)
                .Bind(resultSum => Subtraction(resultSum))
                .Bind(resultSubtraction => Division(decimal.Parse(resultSubtraction.ToString())))
                .Bind(resultDivision => Multiplication(int.Parse(resultDivision.ToString())))
                .Match(left: l => 0, right: r => r);
            
            // Assert's
            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 1, 0)]
        public void BindDivideByZeroFailed(int v1, int v2, int v3, int v4, int expected)
        {
            // Assert
            Func<int, Either<Exception, int>> Sum = i => Try<int>.Cath(() => i);
            Func<int, Either<Exception, double>> Subtraction = i => Try<double>.Cath(() => i - 2);
            Func<decimal, Either<Exception, decimal>> Division = arg => Try<decimal>.Cath(() => arg / 0);
            Func<int, Either<Exception, int>> Multiplication = arg => Try<int>.Cath(() => arg * 3);
            
            // Act
            var result = Sum(v1 + v2 + v3 + v4)
                .Bind(resultSum => Subtraction(resultSum))
                .Bind(resultSubtraction => Division(decimal.Parse(resultSubtraction.ToString())))
                .Bind(resultDivision => Multiplication(int.Parse(resultDivision.ToString())));
                
            
            // Assert's
            result.Match(left => {
                left.Should().BeOfType<DivideByZeroException>();
                return 0;
            }, right: r => r).Should().Be(expected);
        }
    }
}