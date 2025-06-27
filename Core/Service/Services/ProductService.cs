using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Domain.Exceptions.ProductExceptions;
using Service.Abstraction.IServices;
using Service.Specifications;
using Shared.Dtos;
using Shared.QueryParams;
using Shared.Results;

namespace Service.Services
{
    public class ProductService(IUnitOfWork unitOfWork, IMapper mapper): IProductService
    {
        public async Task<PaginatedResult<ProductDto?>> GetAllAsync(ProductQueryParams queryParams)
        {
            int? totalCount = await unitOfWork.GetRepository<Product, int>().GetCountAsync(new ProductCountSpecification(queryParams));
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync(new ProductSpecification(queryParams));
            
            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);
            var productDtos = productsDto.ToList();
            var result = new PaginatedResult<ProductDto?>(productDtos, totalCount?? 0, queryParams.PageIndex,
                productDtos.Count());
            return result;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            //var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);
            var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(new ProductSpecification(id));
            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }
            var productDto = mapper.Map<ProductDto>(product);
            return productDto;
        }
    }
}
