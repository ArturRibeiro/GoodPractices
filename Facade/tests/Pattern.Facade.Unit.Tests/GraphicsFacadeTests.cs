using Pattern.Facade.Unit.Testing.Fakers;

namespace Pattern.Facade.Unit.Testing
{
    public class GraphicsFacadeTests
    {
        [Theory]
        [ClassData(typeof(GraphicsFacadeFaker))]
        public void Facade(Action action)
        {
            // Arrange
            
            // Act
            action();

            // Assert's
        }
    }
}