namespace Writing.Architecture.Unit.Tests
{
    public class ApplicationTests
    {
        [Theory(DisplayName = "Application should Not Have Dependency On Other Projects")]
        [ClassData(typeof(RulesApplication))]
        public void ApplicationShouldNotHaveDependencyOnOtherProjects(Assembly assembly, string referenceProject)
        {
            // Arrange
            assembly.Should().NotBeNull();
            referenceProject.Should().NotBeNull();
            
            // Act
            var result = Types.InAssembly(assembly)
                .ShouldNot()
                .HaveDependencyOn(referenceProject)
                .GetResult();

            // Assert
            result.IsSuccessful.Should().BeTrue();
        }
    }
}