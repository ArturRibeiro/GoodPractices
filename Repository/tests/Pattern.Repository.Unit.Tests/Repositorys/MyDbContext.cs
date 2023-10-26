namespace Pattern.Repository.Unit.Tests.Repositorys
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }
    }
}