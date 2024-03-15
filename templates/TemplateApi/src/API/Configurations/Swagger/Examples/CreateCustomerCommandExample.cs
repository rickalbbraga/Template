using Application.Commands.Customer;
using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;

namespace API.Configurations.Swagger.Examples
{
    /// <summary>
    /// Cria um exemplo para o Payload
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CreateCustomerCommandExample : IExamplesProvider<CreateCustomerCommand>
    {
        public CreateCustomerCommand GetExamples()
        {
            return new CreateCustomerCommand
            {
                Document = "99.999.999-44",
                Email = "jose@gmail.com",
                Name = "José Mário Gomes"
            };
        }
    }
}
