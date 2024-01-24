namespace TablePerHierarchy.Infra;

public class ApplicationTphDbContext : DbContext
{
    public DbSet<Person> Peoples { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        optionsBuilder.UseSqlite($"Data Source={currentDirectory}/TablePerHierarchy.db")
            .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name });
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("PersonType")
            .HasValue<Person>("Person")
            .HasValue<Employee>("Employee");
    }
}