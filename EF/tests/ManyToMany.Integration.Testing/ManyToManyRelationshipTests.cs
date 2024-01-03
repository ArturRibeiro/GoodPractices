using FluentAssertions;

namespace ManyToMany.Integration.Testing;

public class ManyToManyRelationshipTests
{
    [Fact(DisplayName = "Entity Framework Core Many-to-Many Relationship")]
    public void EntityFrameworkCoreManyToManyRelationshipSuccess()
    {
        using var context =  new ManyToManyDbContext();
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var student = new Student();
        student.Name = "Artur";
        student.Courses.Add(new Course(){Title = "A1"});
        student.Courses.Add(new Course(){Title = "A2"});
        student.Courses.Add(new Course(){Title = "A3"});
        student.Courses.Add(new Course(){Title = "A4"});
        student.Courses.Add(new Course(){Title = "A5"});
        context.Students.Add(student);
        context.SaveChanges();
        
        
        using var context2 =  new ManyToManyDbContext();
        var studentRead = context2.Students
            .Include(x => x.Courses)
            .First();

        studentRead.Should().NotBeNull();
        studentRead.Courses.Should().NotBeNull();
        studentRead.Courses.Should().HaveCount(5);
    }
}