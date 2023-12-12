namespace Shop.Infrastructure.Repositorys;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : Entity<long>
{
    private readonly ApplicationDbContext _context;

    public GenericRepository(ApplicationDbContext context) => _context = context;
    
    public IEnumerable<TEntity> GetAll() => _context.Set<TEntity>().ToList();

    public TEntity GetById(long id) => _context.Set<TEntity>().Find(id);

    public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);

    public void Update(TEntity entity) => _context.Entry(entity).State = EntityState.Modified;

    public void Remove(TEntity entity) => _context.Set<TEntity>().Remove(entity);
    public IUnitOfWork UnitOfWork => _context;
}