namespace GraphQL.Api.GraphTypes.Mutations.InputTypes.Inputs;

public class AddPostInput
{
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
}