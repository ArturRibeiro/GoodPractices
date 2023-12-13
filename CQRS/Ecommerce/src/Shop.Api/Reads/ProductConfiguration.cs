namespace Shop.Api.Reads;

public record ProductConfiguration : IEntityTypeConfiguration<ProductReadModel>
{
    public void Configure(EntityTypeBuilder<ProductReadModel> builder)
    {
        builder.ToTable("Producs");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name);
        builder.Property(p => p.Description);
        builder.Property(p => p.UnitPrice);
        builder.Property(p => p.QuantityInStock);
    }
}