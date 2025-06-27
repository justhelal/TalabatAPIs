using Shared.Dtos;
using Shared.QueryParams;
using Shared.Results;

namespace Service.Abstraction.IServices
{
    public interface IProductService
    {
        Task<PaginatedResult<ProductDto?>> GetAllAsync(ProductQueryParams queryParams);
        Task<ProductDto> GetByIdAsync(int id);
    }
}