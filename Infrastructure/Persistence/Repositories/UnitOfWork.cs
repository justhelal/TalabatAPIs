using Persistence.Data;

namespace Persistence.Repositories
{
    public class UnitOfWork(AppDbContext dbContext): IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var key = typeof(TEntity).Name;
            if (_repositories.TryGetValue(key, out var value))
            {
                return (IGenericRepository<TEntity, TKey>)value;
            }
            _repositories[key] = new GenericRepository<TEntity, TKey>(dbContext);
            return (IGenericRepository<TEntity, TKey>)_repositories[key];
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
