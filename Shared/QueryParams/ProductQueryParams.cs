using System.Linq.Expressions;
using Domain.Entities.ProductModule;
using Shared.QueryParams.Enums;

namespace Shared.QueryParams
{
    public class ProductQueryParams
    {
        public string? Search { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }

        public int PageIndex { get; set; } = 1;

        private int _pageSize = 5;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > 10 ? 10 : value;
        }

        public ProductSortingOptions SortingOptions { get; set; }
        public Expression<Func<Product, bool>> GetExpression()
        {
            return p => 
                (!TypeId.HasValue || p.TypeId == TypeId) &&
                (!BrandId.HasValue || p.BrandId == BrandId) &&
                (string.IsNullOrEmpty(Search) || p.Name.ToLower().Contains(Search));
        }
    }
}
