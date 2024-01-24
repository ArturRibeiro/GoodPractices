namespace TablePerConcrete.Infra;

public class ApplicationTpcDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        optionsBuilder.UseSqlite($"Data Source={currentDirectory}/TablePerConcrete.db")
            .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name });
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Customer>().ToTable("Customers");
    }
}