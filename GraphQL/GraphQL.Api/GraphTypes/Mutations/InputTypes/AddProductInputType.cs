using GraphQL.Api.GraphTypes.Mutations.InputTypes.Inputs;

namespace GraphQL.Api.GraphTypes.Mutations.InputTypes;

public class AddPostInputType : InputObjectType<AddPostInput>
{
    protected override void Configure(IInputObjectTypeDescriptor<AddPostInput> descriptor)
    {
        descriptor.Description("Represents the input to add for a Post.");

        descriptor.Field(c => c.UserId);
        descriptor.Field(c => c.Title);
        descriptor.Field(c => c.Content);

        base.Configure(descriptor);
    }
}