namespace Shop.Infrastructure.Configurations;

public class EventSourcingConfiguration: IEntityTypeConfiguration<Storage>
{
    public void Configure(EntityTypeBuilder<Storage> builder)
    {
        builder.ToTable("Storage");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnOrder(1).HasColumnName("Id").IsRequired();
        builder.Property(x => x.CommandId).HasColumnOrder(2).HasColumnName("IdempotentId").IsRequired();
        builder.Property(x => x.Name).HasColumnOrder(3).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Json).HasColumnOrder(4).HasColumnName("Json").IsRequired();
    }
}