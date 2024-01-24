namespace ManyToMany.Domain;

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    
    public ICollection<Student> Students { get; set; }
}