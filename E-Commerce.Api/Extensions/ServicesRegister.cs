using Microsoft.AspNetCore.Mvc;
using Shared.ErrorModels;

namespace E_Commerce.Api.Extensions
{
    public static class ServicesRegister
    {
        public static IServiceCollection AddSwaggerCollection(this IServiceCollection Services)
        {
            Services.AddSwaggerGen();
            Services.AddEndpointsApiExplorer();
            return Services;
        }

        public static IServiceCollection AddWebApplicationServices(this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var error = context.ModelState
                        .Where(e => e.Value?.Errors.Count > 0)
                        .Select(e => new ValidationError()
                        {
                            Field = e.Key,
                            Errors = e.Value?.Errors.Select(x => x.ErrorMessage)
                        });
                    var response = new ValidationResponse()
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Errors = error
                    };
                    return new BadRequestObjectResult(response);
                };
            });

            return Services;
        }
    }
}
