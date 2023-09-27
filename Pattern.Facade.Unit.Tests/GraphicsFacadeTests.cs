namespace Pattern.Facade.Unit.Tests
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