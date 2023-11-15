namespace GraphQL.Api.Infra.Domain;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreationDate { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }
}