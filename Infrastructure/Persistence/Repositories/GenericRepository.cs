using Persistence.Data;

namespace Persistence.Repositories
{
    public class GenericRepository<TEntity, TKey> (AppDbContext dbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await dbContext.Set<TEntity>().ToListAsync();
        

        public async Task<TEntity?> GetByIdAsync(TKey id)
        => await dbContext.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> specification)
            => await ApplySpecification(specification).ToListAsync();

        public async Task<int?> GetCountAsync(ISpecification<TEntity, TKey> specification)
        => await ApplySpecification(specification).CountAsync();


        public async Task<TEntity?> GetByIdAsync(ISpecification<TEntity, TKey> specification)
            => await ApplySpecification(specification).FirstOrDefaultAsync();

        public async Task AddAsync(TEntity entity)
        => await dbContext.Set<TEntity>().AddAsync(entity);

        public void UpdateAsync(TEntity entity)
        => dbContext.Set<TEntity>().Update(entity);

        public void DeleteAsync(TEntity entity)
        => dbContext.Set<TEntity>().Remove(entity);

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity, TKey> specification)
            => SpecificationEvaluator.GetQuery(dbContext.Set<TEntity>(), specification);
    }
}
