namespace Shop.Infrastructure.Abstractions.Impl;

public class ApplicationUserMock : IApplicationUser
{
    public int UserId => 1;
    public string Name => "Ribeiro";
}