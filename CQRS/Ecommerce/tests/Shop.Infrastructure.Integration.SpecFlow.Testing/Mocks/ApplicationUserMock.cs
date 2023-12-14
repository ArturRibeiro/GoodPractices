namespace Shop.Infrastructure.Integration.SpecFlow.Testing.Mocks;

public class ApplicationUserMock : IApplicationUser
{
    public int UserId => 1;
    public string Name => "Ribeiro";
}