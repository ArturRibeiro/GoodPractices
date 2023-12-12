namespace Shop.Domain.SharedKernel;

public interface IGenericRepository<TEntity> where TEntity : Entity<long>
{
    IEnumerable<TEntity> GetAll();
    TEntity GetById(long id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    IUnitOfWork UnitOfWork { get; }
}