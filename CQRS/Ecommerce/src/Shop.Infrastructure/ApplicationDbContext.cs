using Shop.Infrastructure.Seed;

namespace Shop.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}