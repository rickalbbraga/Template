using Application.Queries.Customer;
using Application.Responses.Customer;
using Domain.Interfaces.CQS;
using Domain.Interfaces.Repositories;

namespace Application.Handlers.Customer
{
    public class GetAllCustomerHandler(
        ICustomerRepository customerRepository) : IQueryHandlerWithTResultList<GetAllCustomerQuery, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<IList<CustomerResponse>?> HandleAsync(GetAllCustomerQuery query)
        {
            var customerList = await _customerRepository.GetAllAsync();

            if (customerList is null) return []; 

            return customerList.AsEnumerable().Select(c => new CustomerResponse
            {
                Uid = c.Uid,
                Name = c.Name,
                Document = c.Document,
                Email = c.Email
            }).ToList();
        }
    }
}
