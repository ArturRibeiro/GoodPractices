namespace Shop.Api.Reads;

public class ApplicationDbContextReadOnly : DbContext
{
    public ApplicationDbContextReadOnly(DbContextOptions<ApplicationDbContextReadOnly> options)
        : base(options) => this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContextReadOnly).Assembly);

    public DbSet<ProductReadModel> ProductReadModels { get; set; }
}