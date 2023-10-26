namespace Pattern.Repository.Imp
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>  where TEntity : class
    {
        private readonly DbContext _context;
        private DbSet<TEntity> set;

        protected GenericRepository(DbContext context)
        {
            _context = context;
            this.set = _context.Set<TEntity>();
        }
        
        public virtual IEnumerable<TEntity?> GetAll() => this.set.ToList();

        public virtual TEntity? GetById(object? id) => this.set.Find(id);

        public virtual void Insert(TEntity entity) => this.set.Add(entity);

        public virtual void Update(TEntity entity)
        {
            this.set.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity) => this.set.Remove(entity);

        public virtual void Save() => _context.SaveChanges();
    }
}