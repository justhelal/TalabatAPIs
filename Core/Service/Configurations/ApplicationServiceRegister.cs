using Microsoft.Extensions.DependencyInjection;
using Service.Abstraction;
using Service.Services;

namespace Service.Configurations
{
    public static class ApplicationServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
            return services;
        }

    }
}
