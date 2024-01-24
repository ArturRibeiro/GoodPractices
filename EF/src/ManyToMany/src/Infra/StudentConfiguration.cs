using ManyToMany.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.Infra;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.StudentId);
        builder.Property(x => x.Name);

        builder.HasMany(s => s.Courses)
            .WithMany(c => c.Students)
            .UsingEntity<Dictionary<string, object>>(
                right => right
                    .HasOne<Course>()
                    .WithMany()
                    .HasForeignKey("CourseId"),
                left => left
                    .HasOne<Student>()
                    .WithMany()
                    .HasForeignKey("StudentId"),
                join => join
                    .ToTable("StudentCourses")
                    .HasKey("StudentId", "CourseId")
            );
    }
}