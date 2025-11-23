namespace SampleCleanArchitecture.Infrastructure.Manager
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<TEntity> _dbSet;
        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<TEntity>();
        }

        public IQueryable<TEntity> FindAll(bool trackChanges) => !trackChanges ? _applicationDbContext.Set<TEntity>().AsNoTracking() : _applicationDbContext.Set<TEntity>();
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges) =>
            !trackChanges ? _applicationDbContext.Set<TEntity>().Where(expression).AsNoTracking() : _applicationDbContext.Set<TEntity>().Where(expression);


        public void Create(TEntity entity) => _applicationDbContext.Set<TEntity>().Add(entity);
        public void Update(TEntity entity) => _applicationDbContext.Set<TEntity>().Update(entity);
        public void Delete(TEntity entity) => _applicationDbContext.Set<TEntity>().Remove(entity);



       
    }

}
