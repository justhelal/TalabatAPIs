using Domain.Entities.ProductModule;
using Shared.QueryParams;
using Shared.QueryParams.Enums;

namespace Service.Specifications
{
    class ProductSpecification : Specification<Product, int>
    {
        
        public ProductSpecification(int id) : base(product => product.Id == id)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }

        public ProductSpecification(ProductQueryParams queryParams): base(queryParams.GetExpression())
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
            switch (queryParams.SortingOptions)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(product => product.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDesc(product => product.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(product => product.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDesc(product => product.Price);
                    break;
            }   

            ApplyPaging(queryParams.PageIndex , queryParams.PageSize);
        }
    }
}
