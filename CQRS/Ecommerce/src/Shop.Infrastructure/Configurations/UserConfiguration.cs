namespace Shop.Infrastructure.Configurations;

public record UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(u => u.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.Email);
        builder.Property(u => u.Registered);
    }
}