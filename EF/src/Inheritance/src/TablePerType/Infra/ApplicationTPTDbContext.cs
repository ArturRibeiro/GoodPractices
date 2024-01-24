namespace TablePerType.Infra;

public class ApplicationTptDbContext : DbContext
{
    public DbSet<Person> Peoples { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        optionsBuilder.UseSqlite($"Data Source={currentDirectory}/TablePerType.db")
            .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name });
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().ToTable("People");
        modelBuilder.Entity<Employee>().ToTable("Employees");
        modelBuilder.Entity<Customer>().ToTable("Customers");
    }
}