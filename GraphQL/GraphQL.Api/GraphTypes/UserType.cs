namespace GraphQL.Api.GraphTypes;

public class UserType : ObjectType<User>
{
    protected override void Configure(IObjectTypeDescriptor<User> descriptor)
    {
        descriptor.Description("Graphql : User Type");
        
        descriptor.Ignore(u => u.Id);
        descriptor.Field(u => u.Email);
        descriptor.Field(u => u.Name);
        descriptor.Ignore(u => u.Password);

        descriptor
            .Field(o => o.Posts)
            .ResolveWith<PostResolver>(o => o.GetPostByUser(default!, default!));
    }
}