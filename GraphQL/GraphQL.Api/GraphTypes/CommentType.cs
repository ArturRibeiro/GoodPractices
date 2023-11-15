namespace GraphQL.Api.GraphTypes;

public class CommentType : ObjectType<Comment>
{
    protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
    {
        descriptor.Description("Graphql : Comment Type");
        
        descriptor.Ignore(u => u.Id);
        descriptor.Ignore(u => u.PostId);
        descriptor.Ignore(u => u.Post);
        
        descriptor.Field(u => u.Content);
        descriptor.Field(u => u.CreationDate);
    }
}