using Domain.Entities;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity,TKey> specification);

        Task<int?> GetCountAsync(ISpecification<TEntity, TKey> specification);
        Task<TEntity?> GetByIdAsync(ISpecification<TEntity, TKey> specification);

        Task AddAsync(TEntity entity);

        void UpdateAsync(TEntity entity);

        void DeleteAsync(TEntity entity);
    }
}
