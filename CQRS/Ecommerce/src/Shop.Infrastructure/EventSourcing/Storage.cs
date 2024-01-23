namespace Shop.Infrastructure.EventSourcing;

public class Storage : Entity<long>
{
    public string Json { get; private set; }
    public string Name { get; private set; }
    public Guid CommandId { get; private set; }
    
    public Storage() { }

    public Storage(Guid id, string name, string json)
    {
        this.CommandId = id;
        this.Name = name;
        this.Json = json;
    }
}