namespace GraphQL.Api.GraphTypes.Queries.Resolvers;

internal record PostResolver
{
    public IEnumerable<Post> GetPostByUser(
        [Parent] User user,
        [Service] ApplicationDbContext context) =>
        context.Posts.Where(x => x.UserId == user.Id).ToList();
}