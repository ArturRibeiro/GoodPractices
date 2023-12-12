namespace Shop.Infrastructure.Abstractions;

public interface IApplicationUser
{
    int UserId { get; }
    string Name { get;}
}