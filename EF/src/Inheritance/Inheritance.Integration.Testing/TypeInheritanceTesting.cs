namespace Inheritance.Integration.Testing;

public class TypeInheritanceTesting
{
    [Fact(DisplayName = "Table Per Hierarchy (TPH)")]
    public async Task TPH()
    {
        var context = new ApplicationTPHDbContext();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        context.Peoples.Add(new TPH.Domain.Person() { Name = "Person 1"});
        context.Peoples.Add(new TPH.Domain.Employee() { Name = "Employee 1", JobTitle = "JobTitle" });

        await context.SaveChangesAsync();
    }
    
    [Fact(DisplayName = "Table Per Type (TPT)")]
    public async Task TPT()
    {
        var context = new ApplicationTPTDbContext();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        
        context.Peoples.Add(new TPT.Domain.Person() { Name = "Person 1"});
        context.Peoples.Add(new TPT.Domain.Employee() { Name = "Employee 1", JobTitle = "JobTitle" });
        context.Peoples.Add(new TPT.Domain.Customer() { Name = "Customer 1", CustomerType = "1"});

        await context.SaveChangesAsync();
    }
    
    [Fact(DisplayName = "Table Per Concrete Type (TPC)")]
    public async Task TPC()
    {
        var context = new ApplicationTPCDbContext();
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        
        context.Employees.Add(new TPC.Domain.Employee() { Name = "Person 1", JobTitle = "Job 1"});
        context.Customers.Add(new TPC.Domain.Customer() { Name = "Customer 1", CustomerType = "1"});
        
        await context.SaveChangesAsync();
    }
}