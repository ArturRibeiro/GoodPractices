namespace Inheritance.Integration.Testing;

public class TypeInheritanceTesting
{
    [Fact(DisplayName = "Table Per Hierarchy (TablePerHierarchy)")]
    public async Task TPH()
    {
        // Arrange's
        var context = new ApplicationTphDbContext();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        // Act
        context.Peoples.Add(new TablePerHierarchy.Domain.Person() { Name = "Person 1"});
        context.Peoples.Add(new TablePerHierarchy.Domain.Employee() { Name = "Employee 1", JobTitle = "JobTitle" });
        await context.SaveChangesAsync();
    }
    
    [Fact(DisplayName = "Table Per Type (TablePerType)")]
    public async Task TablePerType()
    {
        // Arrange's
        var context = new ApplicationTptDbContext();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        
        // Act
        context.Peoples.Add(new TablePerType.Domain.Person() { Name = "Person 1"});
        context.Peoples.Add(new TablePerType.Domain.Employee() { Name = "Employee 1", JobTitle = "JobTitle" });
        context.Peoples.Add(new TablePerType.Domain.Customer() { Name = "Customer 1", CustomerType = "1"});
        await context.SaveChangesAsync();
    }
    
    [Fact(DisplayName = "Table Per Concrete (TPC)")]
    public async Task TPC()
    {
        // Arrange's
        var context = new ApplicationTpcDbContext();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        
        // Act
        context.Employees.Add(new Employee() { Name = "Person 1", JobTitle = "Job 1"});
        context.Customers.Add(new Customer() { Name = "Customer 1", CustomerType = "1"});
        await context.SaveChangesAsync();
    }
}