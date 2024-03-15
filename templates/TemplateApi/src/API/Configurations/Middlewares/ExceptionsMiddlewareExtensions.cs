using System.Diagnostics.CodeAnalysis;

namespace API.Configurations.Middlewares
{
    [ExcludeFromCodeCoverage]
    public static class ExceptionsMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
