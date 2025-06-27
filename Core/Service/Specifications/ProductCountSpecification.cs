using Domain.Entities.ProductModule;
using Shared.QueryParams;

namespace Service.Specifications
{
    public class ProductCountSpecification(ProductQueryParams queryParams) : Specification<Product, int>(queryParams.GetExpression())
    {
    }
}
