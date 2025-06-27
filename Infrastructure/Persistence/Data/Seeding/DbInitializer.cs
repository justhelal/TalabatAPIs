using Domain.Entities.ProductModule;

namespace Persistence.Data.Seeding
{
    public class DbInitializer (AppDbContext _dbContext) : IDbInitializer
    {
        public async Task InitializeAsync()
        {
			try
			{
                var getPendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                if (getPendingMigrations.Any())
				{
					await _dbContext.Database.MigrateAsync();
					if(!_dbContext.ProductTypes.Any())
					{
						var typeData = File.OpenRead(@"..\Infrastructure\Persistence\Data\Seeding\JsonFiles\types.json");
						var types = await JsonSerializer.DeserializeAsync<List<ProductType>>(typeData);
						if(types is not null && types.Count != 0)
						{
                            await _dbContext.ProductTypes.AddRangeAsync(types);
                        }
                    }
                    if (!_dbContext.ProductBrands.Any())
                    {
                        var brandData = File.OpenRead(@"..\Infrastructure\Persistence\Data\Seeding\JsonFiles\brands.json");
                        var brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(brandData);
                        if (brands is not null && brands.Count != 0)
                        {
                            await _dbContext.ProductBrands.AddRangeAsync(brands);
                        }
                    }
                    if (!_dbContext.Products.Any())
                    {
                        var productData = File.OpenRead(@"..\Infrastructure\Persistence\Data\Seeding\JsonFiles\products.json");
                        var products = await JsonSerializer.DeserializeAsync<List<Product>>(productData);
                        if (products is not null && products.Count != 0)
                        {
                            await _dbContext.Products.AddRangeAsync(products);
                        }
                    }
                    await _dbContext.SaveChangesAsync();
                }

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
