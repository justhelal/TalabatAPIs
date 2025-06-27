using Azure;
using Domain.Exceptions;
using Shared.ErrorModels;

namespace E_Commerce.Api.CustomMiddlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);

                await HandleNotFoundEndPoint(context);
            }
            catch (Exception ex)
            {
                await HandleExceptions(context, ex);
            }
        }

        private static async Task HandleNotFoundEndPoint(HttpContext context)
        {
            if (context.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                var error = new Error
                {
                    StatusCode = context.Response.StatusCode,
                    Message = $"Endpoint {context.Request.Path} is not found"
                };
                await context.Response.WriteAsJsonAsync(error);
            }
        }

        private async Task HandleExceptions(HttpContext context, Exception ex)
        {
            logger.LogError(ex, "An error occurred while processing the request.");
            context.Response.StatusCode = ex switch
            {
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };
            context.Response.ContentType = "application/json";

            var error = new Error
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            };

            // Serialize the error object to JSON and write it to the response
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}
