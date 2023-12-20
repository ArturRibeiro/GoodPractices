namespace Shop.Domain.Clients;

public class Client : User
{
    public Address Address { get; private set; }
    
    public Client()
    {
        
    }

    public Client(long id) => this.Id = id;
}