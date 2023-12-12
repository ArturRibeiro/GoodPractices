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
        
        [Theory]
        [InlineData(1)]
        public void ShoppingCartServiceSuccess(int productId)
        {
            var service = new ShoppingCartService();

            // Arrange
            Either<Exception, IEnumerable<Product>> AllProductsAvailable() => Try<IEnumerable<Product>>.Cath(() => service.GetProducts());
            Either<Exception, Product?> SearchByProduct(IEnumerable<Product> list, int id) => Try<Product?>.Cath(() => list.FirstOrDefault(x => x.Id == id));
            Either<Exception, ShoppingCart> AddCar(Product? product) => Try<ShoppingCart>.Cath(() => service.AddToCart(product));
            Action<Exception> HandlerError = (exception) => {/*TODO: Loga o error*/};
            
            // Act
            var result =
                AllProductsAvailable()
                    .Bind(products => SearchByProduct(products, productId))
                    .Bind(product => AddCar(product))
                    .Match(left => { HandlerError(left);
                        return null;
                    }, right => right);
                
            
            // Assert's
            result.Items.Should().HaveCount(1);
            result.Items.ElementAt(0).Id.Should().Be(productId);
        }

        [Fact]
        public void Test()
        {
            var leftValue = Either<string, int>.Left("Error");
            var rightValue = Either<string, int>.Right(42);

            var result1 = leftValue.Map(value => value * 2);
            var result2 = rightValue.Map(value => value * 2);

            string c1 = result1.Match(error => $"Left: {error}", value => $"Right: {value}");
            var c2 = result2.Map(value => value);
            
            Console.WriteLine(c1);
            Console.WriteLine(c2);
        }
    }
}