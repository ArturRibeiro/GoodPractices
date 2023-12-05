public record Dummy(Guid Id);

public class DummyType : ObjectType<Dummy>
{
     protected override void Configure(IObjectTypeDescriptor<Dummy> descriptor)
     {
         descriptor.Description("Graphql : Dummy Type");

         descriptor.Field(u => u.Id);
     }
}