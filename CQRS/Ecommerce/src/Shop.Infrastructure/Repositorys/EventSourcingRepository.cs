namespace Shop.Infrastructure.Repositorys;

public class EventSourcingRepository : GenericRepository<Storage>, IEventSourcingRepository
{
    public EventSourcingRepository(ApplicationDbContext context) 
        : base(context)
    {
    }
}