namespace GraphQL.Api.Queries;

[ExtendObjectType("Query")]
public record UserQuery
{
    public IEnumerable<User> Users(
        [Service] ApplicationDbContext context)
        => context.Users.ToList();

    public User User(
        [Service] ApplicationDbContext context,
        int id)
        => context.Users.Find(id);
}