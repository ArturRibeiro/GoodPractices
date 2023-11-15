namespace GraphQL.Api.GraphTypes.Queries.Resolvers;

internal record CommentResolver
{
    public IEnumerable<Comment> GetCommentByPost(
        [Parent] Post post,
        [Service] ApplicationDbContext context) =>
        context.Comments.Where(x => x.PostId == post.Id).ToList();
}