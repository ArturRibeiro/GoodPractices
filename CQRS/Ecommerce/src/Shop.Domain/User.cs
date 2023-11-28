namespace Shop.Domain;

public class User : Entity<long>
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime Registered { get; private set; }

    public User() { }

    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}