using System.Data;
using Domain.Entities.BasketModule;
using StackExchange.Redis;

namespace Persistence.Repositories
{
    public class BasketRepository(IConnectionMultiplexer redisConnection): IBasketRepository
    {
        private readonly IDatabase _database = redisConnection.GetDatabase();
        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {
            var basket =  await _database.StringGetAsync(basketId);
            if (string.IsNullOrEmpty(basket))
                return null;
            return JsonSerializer.Deserialize<CustomerBasket>(basket!);
        }

        public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? span)
        {
            var jsonBasket = JsonSerializer.Serialize(basket);
            bool check = await _database.StringSetAsync(basket.Id, jsonBasket, span ?? TimeSpan.FromDays(30));
            return  check ? await GetBasketAsync(basket.Id) : null;
        }
            
        public async Task<bool> DeleteBasketAsync(string basketId)
        => await _database.KeyDeleteAsync(basketId);
        
    }
}
