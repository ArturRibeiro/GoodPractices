namespace GraphQL.Api.Infra.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Name).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Password).IsRequired();
        builder.HasMany(u => u.Posts).WithOne(p => p.User).HasForeignKey(p => p.UserId);
    }
}