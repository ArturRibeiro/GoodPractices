namespace Shop.Infrastructure.Configurations;

public record ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Producs");
        
        builder.HasKey(p => p.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Description)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired();

        builder.Property(p => p.QuantityInStock)
            .IsRequired();
    }
}