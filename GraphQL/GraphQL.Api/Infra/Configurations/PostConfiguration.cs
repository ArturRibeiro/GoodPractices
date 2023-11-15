namespace GraphQL.Api.Infra.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.Content).IsRequired();
        builder.Property(p => p.CreationDate).IsRequired();
        builder.HasOne(p => p.User).WithMany(u => u.Posts).HasForeignKey(p => p.UserId);
        builder.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId);
    }
}