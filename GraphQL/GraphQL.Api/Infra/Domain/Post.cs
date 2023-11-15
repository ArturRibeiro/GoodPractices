namespace GraphQL.Api.Infra.Domain;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }
    public List<Comment> Comments { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}