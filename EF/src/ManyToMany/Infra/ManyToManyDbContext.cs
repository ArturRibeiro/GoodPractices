using ManyToMany.Domain;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Infra;

public class ManyToManyDbContext : DbContext
{

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManyToManyDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        optionsBuilder.UseSqlite($"Data Source={currentDirectory}\\Post.db")
            .LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name });
    }
}