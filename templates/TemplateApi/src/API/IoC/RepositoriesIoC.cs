using Domain.Interfaces.Repositories;
using Infra.Data.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace API.IoC
{
    [ExcludeFromCodeCoverage]
    public static class RepositoriesIoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerRepository>(_ => new CustomerRepository(configuration.GetSection("SqlServer").Value ?? string.Empty));

            return services;
        }
    }
}
