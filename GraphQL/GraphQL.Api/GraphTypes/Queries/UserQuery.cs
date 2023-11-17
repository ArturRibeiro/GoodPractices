namespace GraphQL.Api.GraphTypes.Queries;

[ExtendObjectType("Query")]
public record UserQuery
{
    [UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
    [UseFiltering]
    public IQueryable<User> Users(
        [Service] ApplicationDbContext context)
        => context.Users;

    public User User(
        [Service] ApplicationDbContext context,
        int id)
        => context.Users.Find(id);
}