using Domain.Entities;

namespace Shared.Results
{
    public record PaginatedResult<TEntity>
    (
        IEnumerable<TEntity> Items,
        int TotalCount,
        int PageIndex,
        int PageSize
    )
    {
       
        
    }
}
