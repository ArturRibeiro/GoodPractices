using Pattern.Repository.Imp;

namespace Pattern.Repository.Unit.Tests.Repositorys
{
    public class PersonRepository : GenericRepository<Person>
    {
        public PersonRepository(MyDbContext context)
            : base(context)
        {
        }
    }
}