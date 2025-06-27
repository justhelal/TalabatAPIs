using AutoMapper;
using Domain.Contracts;
using Service.Abstraction;
using Service.Abstraction.IServices;

namespace Service.Services
{
    public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper) : IServiceManager
    {
        private readonly Lazy<ProductService> _productService = new Lazy<ProductService>(() => new ProductService(unitOfWork, mapper));

        public IProductService ProductService => _productService.Value;
    }
}
