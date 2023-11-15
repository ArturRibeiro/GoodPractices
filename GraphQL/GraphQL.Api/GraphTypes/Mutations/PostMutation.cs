using GraphQL.Api.GraphTypes.Mutations.InputTypes.Inputs;

namespace GraphQL.Api.GraphTypes.Mutations;

[ExtendObjectType("Mutation")]
public record PostMutation
{
    public Post AddPost(
        AddPostInput input, 
        [Service] ApplicationDbContext context)
    {
        var post = new Post()
        {
            UserId = input.UserId,
            Title = input.Title,
            Content = input.Content,
            CreationDate = DateTime.Now
        };

        context.Posts.Add(post);
        context.SaveChanges();

        return post;
    }
}