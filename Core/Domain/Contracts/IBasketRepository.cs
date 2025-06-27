using Domain.Entities.BasketModule;

namespace Domain.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string basketId);
        Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? span);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
