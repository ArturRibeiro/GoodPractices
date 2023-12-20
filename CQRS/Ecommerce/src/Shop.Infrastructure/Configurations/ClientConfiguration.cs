namespace Shop.Infrastructure.Configurations;

public record ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.OwnsOne(o => o.Address
            , oneBuilder =>
            {
                oneBuilder.Property(x => x.Street).HasColumnName("Street");
                oneBuilder.Property(x => x.City).HasColumnName("City");
                oneBuilder.Property(x => x.State).HasColumnName("State");
                oneBuilder.Property(x => x.Country).HasColumnName("Country");
                oneBuilder.Property(x => x.ZipCode).HasColumnName("ZipCode");
            });
    }
}