namespace Shop.Infrastructure.Configurations;

public record OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        
        builder.HasKey(o => o.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();
        builder.Property(u => u.Registered);
        builder.Property(u => u.ClientId);
        builder.Property(u => u.PaymentId);
        builder.HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey(item => item.OrderId);

        builder.HasOne(o => o.Buyer);
        
        builder.OwnsOne(o => o.TotalPrice
            , oneBuilder =>
            {
                oneBuilder.Property(x => x.Value).HasColumnName("TotalPrice");
            });
        
        builder.OwnsOne(o => o.Status
            , oneBuilder =>
            {
                oneBuilder.Property(x => x.Id).HasColumnName("StatusId");
                oneBuilder.Property(x => x.Description).HasColumnName("StatusName");
            });
        
        builder.OwnsOne(o => o.Payment
            , oneBuilder =>
            {
                oneBuilder.ToTable("PaymentInfo");
                oneBuilder.Property(x => x.ExpirationDate).HasColumnName("ExpirationDate");
                oneBuilder.Property(x => x.CardNumber).HasColumnName("CardNumber");
                oneBuilder.Property(x => x.Cvv).HasColumnName("Cvv");
            });
    }
}