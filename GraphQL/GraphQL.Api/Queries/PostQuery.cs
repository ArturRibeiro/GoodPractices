namespace GraphQL.Api.Queries;

[ExtendObjectType("Query")]
public record PostQuery
{
    public IEnumerable<Post> Posts([Service] ApplicationDbContext service) => service.Posts.ToList();

    public Post Post([Service] ApplicationDbContext service, int id) => service.Posts.Find(id);
}