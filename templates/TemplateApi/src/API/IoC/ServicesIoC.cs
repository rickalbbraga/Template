using Application.Helpers.Builders;
using Application.Responses.Customer;
using Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace API.IoC
{
    [ExcludeFromCodeCoverage]
    public static class ServicesIoC
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IResponseBuilder<CustomerResponse, Customer>, ResponseBuilder<CustomerResponse, Customer>>();

            return services;
        }
    }
}
