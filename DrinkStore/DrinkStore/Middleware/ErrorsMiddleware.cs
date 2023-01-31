using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DrinkStore.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorsMiddleware> _logger;


        public ErrorsMiddleware(RequestDelegate next, ILogger<ErrorsMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {
                _logger.LogError($"error happend!!! " + error.Message + "\\n" + error.StackTrace);
                await _next(httpContext);

            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorsMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorsMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorsMiddleware>();
        }
    }
}
