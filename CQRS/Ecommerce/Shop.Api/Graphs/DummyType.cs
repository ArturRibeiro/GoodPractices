public record Dummy
{
    public int Id { get; set; } 
}

public class DummyType : ObjectType<Dummy>
{
     protected override void Configure(IObjectTypeDescriptor<Dummy> descriptor)
     {
         descriptor.Description("Graphql : User Type");

         descriptor.Field(u => u.Id);
     }
}