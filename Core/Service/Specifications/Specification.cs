using System.Linq.Expressions;
using Domain.Contracts;
using Domain.Entities;

namespace Service.Specifications
{
    public abstract class Specification<TEntity, TKey>(Expression<Func<TEntity, bool>>? criteria = null)
        : ISpecification<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; } = criteria;
        public List<Expression<Func<TEntity, object>>> Includes { get; } = [];
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDesc { get; private set; }
        public bool IsPagingEnabled { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression)
            => Includes.Add(includeExpression);
        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
            => OrderBy = orderByExpression;
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDescExpression)
            => OrderByDesc = orderByDescExpression;
        
        protected void ApplyPaging(int pageIndex, int pageSize)
        {
            IsPagingEnabled = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }
    }   
}
