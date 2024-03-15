using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace API.IoC
{
    [ExcludeFromCodeCoverage]
    public static class HandlersIoC
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services, Type[] types)
        {
            var layer = Assembly.GetExecutingAssembly().FullName?.Replace("API", "Application");

            var handlers = Assembly
                            .Load(layer!)
                            .GetTypes()
                            .Where(t => t.GetInterfaces().ToList().Exists(i => i.IsGenericType && types.Contains(i.GetGenericTypeDefinition())));

            foreach (var handler in handlers)
            {
                services.AddScoped(handler.GetInterfaces()[0], handler);
            }

            return services;
        }
    }
}
