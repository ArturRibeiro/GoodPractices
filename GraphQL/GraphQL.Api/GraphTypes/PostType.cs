using GraphQL.Api.GraphTypes.Queries.Resolvers;

namespace GraphQL.Api.GraphTypes;

public class PostType : ObjectType<Post>
{
    protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
    {
        descriptor.Description("Graphql : Post Type");
        
        descriptor.Ignore(u => u.UserId);
        descriptor.Ignore(u => u.User);

        descriptor.Field(u => u.Id);
        descriptor.Field(u => u.Title);
        descriptor.Field(u => u.Content);
        descriptor.Field(u => u.CreationDate);
        
        descriptor
            .Field(o => o.Comments)
            .ResolveWith<CommentResolver>(o => o.GetCommentByPost(default!, default!));
    }
}