namespace GraphQL.Api.Infra.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Content).IsRequired();
        builder.Property(c => c.CreationDate).IsRequired();
        builder.HasOne(c => c.Post).WithMany(p => p.Comments).HasForeignKey(c => c.PostId);
    }
}