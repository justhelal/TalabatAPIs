using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Contracts
{
    public interface ISpecification<TEntity, TKey> where TEntity : BaseEntity<TKey> 
    {
        Expression<Func<TEntity, bool>>? Criteria { get; }
        List<Expression<Func<TEntity, Object>>> Includes { get; }
        public Expression<Func<TEntity, object>>? OrderBy { get; }
        public Expression<Func<TEntity, object>>? OrderByDesc { get; }

        public bool IsPagingEnabled { get; }

        public int Take { get; }

        public int Skip { get; }
    }
}
// criteria => criteria where 