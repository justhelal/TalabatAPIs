using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Data.Seeding;
using Persistence.Repositories;
using StackExchange.Redis;

namespace Persistence
{
    public static class InfrastructureServiceRegister
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IConnectionMultiplexer>(
                (_) => ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection") ?? string.Empty)
            );
            return services;
        }
    }
}
