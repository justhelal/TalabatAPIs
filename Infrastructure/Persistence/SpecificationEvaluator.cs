namespace Persistence
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> GetQuery<TEntity, TKey>(IQueryable<TEntity> inputQuery, ISpecification<TEntity, TKey> specification)
            where TEntity : BaseEntity<TKey>
        {
            var query = inputQuery;
            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }
            //foreach (var include in specification.Includes)
            //{
            //    query = query.Include(include);
            //}
            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if(specification.OrderByDesc is not null)
            {
                query = query.OrderByDescending(specification.OrderByDesc);
            }
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }
            return query;
        }
    }
}
