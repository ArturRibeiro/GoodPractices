namespace GraphQL.Api.Queries;

[ExtendObjectType("Query")]
public record UserQuery
{
    public IEnumerable<User> Users([Service] ApplicationDbContext service) => service.Users.ToList();

    public User User([Service] ApplicationDbContext service, int id) => service.Users.Find(id);
}