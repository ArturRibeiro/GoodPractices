namespace Shop.Infrastructure.Configurations;

public record ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
        builder.Property(i => i.Quantity);
        builder.Property(i => i.OrderId);
        builder.OwnsOne(o => o.UnitPrice
            , oneBuilder =>
            {
                oneBuilder.Property(x => x.Value).HasColumnName("UnitPrice");
            });
        builder.Property(i => i.ProductId).IsRequired();

        builder.Ignore(x => x.Product);
    }
}