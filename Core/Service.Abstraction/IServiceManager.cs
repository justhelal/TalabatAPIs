using Service.Abstraction.IServices;

namespace Service.Abstraction
{
    public interface IServiceManager
    {
        public IProductService ProductService { get; }
    }
}
