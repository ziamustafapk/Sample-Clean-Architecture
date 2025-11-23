namespace SampleCleanArchitecture.Infrastructure.BaseContract
{
    public interface IRepositoryBase<TEntity> 
    {
        public IQueryable<TEntity> FindAll(bool trackChanges);
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
        public void Create(TEntity entity);
        public void Update(TEntity entity); void Delete(TEntity entity);
    }
}
