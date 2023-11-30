public record Dummy
{
    public Guid Id { get; set; } = Guid.NewGuid();
}

public class DummyType : ObjectType<Dummy>
{
     protected override void Configure(IObjectTypeDescriptor<Dummy> descriptor)
     {
         descriptor.Description("Graphql : Dummy Type");

         descriptor.Field(u => u.Id);
     }
}