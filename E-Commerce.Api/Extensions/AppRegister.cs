using Domain.Contracts;
using E_Commerce.Api.CustomMiddlewares;

namespace E_Commerce.Api.Extensions
{
    public static class AppRegister
    {
        public static async Task<IApplicationBuilder> InitializeDatabase (this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await dbInitializer.InitializeAsync();
            return app;
        }
        public static void UseCustomMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
