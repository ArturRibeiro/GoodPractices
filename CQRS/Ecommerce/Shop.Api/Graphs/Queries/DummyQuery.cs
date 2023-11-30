namespace Shop.Api.Graphs.Queries;


[ExtendObjectType("Query")]
public record DummyQuery
{
     public Dummy Dummy()
         => new ();
}