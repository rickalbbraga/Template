using Application.Responses.Customer;
using Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Application.Helpers.Builders
{
    [ExcludeFromCodeCoverage]
    public static class BuildCustomerResponse
    {
        /**
         Caso queira, pode usar o Automapper para fazer o parse de uma entidade para um response (DTO ou ViewModel).
         **/

        public static CustomerResponse? Create(Customer? customer)
        {
            if (customer == null) return null;

            return new CustomerResponse
            {
                Uid = customer.Uid,
                Name = customer.Name,
                Document = customer.Document,
                Email = customer.Email
            };
        }
    }
}
