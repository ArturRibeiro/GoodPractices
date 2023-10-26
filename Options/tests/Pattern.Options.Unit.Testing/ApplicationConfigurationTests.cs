namespace Pattern.Options.Unit.Testing
{
    [Collection("IntegrationTestWebAppFactory")]
    public class ApplicationConfigurationTests
    {
        private readonly IntegrationTestWebAppFactory _context;

        public ApplicationConfigurationTests(IntegrationTestWebAppFactory context) => _context = context;

        [Fact]
        public async Task GetConfiguration()
        {
            // Arrange
            
            // Act
            var options1 = _context.Provider.GetRequiredService<IOptions<ApplicationConfiguration>>();
            
            // Assert's
            options1.Value.Should().NotBeNull();
            options1.Value.PropertieName1.Should().Be("PropertieName1");
            options1.Value.PropertieName2.Should().Be("PropertieName2");
            options1.Value.PropertieName3.Should().Be("PropertieName3");
        }
    }
}