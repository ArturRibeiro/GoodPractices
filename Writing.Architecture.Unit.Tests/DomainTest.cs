namespace Writing.Architecture.Unit.Tests
{
    public class DomainTest
    {
        [Theory(DisplayName = "Domain should Not Have Dependency On Other Projects")]
        [ClassData(typeof(RulesDomain))]
        public void DomainShouldNotHaveDependencyOnOtherProjects(Assembly assembly, string referenceProject)
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