using Application.Helpers.Builders;
using Application.Queries.Customer;
using Application.Responses.Customer;
using Domain.Interfaces.CQS;
using Domain.Interfaces.Repositories;
using Domain.Utils.ErrorMessages;
using Semear.Context.CommonCore.DomainNotification;
using Semear.Context.Logger.Interfaces;
using System.Text.Json;

namespace Application.Handlers.Customer
{
    public class FindCustomerByUidHandler(
        INotificationContext notificationContext,
        ISemearLogService logger,
        ICustomerRepository customerRepository) : IQueryHandlerWithTResult<FindCustomerByUidQuery, CustomerResponse>
    {
        private readonly INotificationContext _notificationContext = notificationContext;
        private readonly ISemearLogService _logger = logger;
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<CustomerResponse?> HandleAsync(FindCustomerByUidQuery query)
        {
            _logger.WriteLogInformation(
                 JsonSerializer.Serialize(
                     new
                     {
                         Message = "Request Received",
                         Query = query,
                         ClassName = nameof(FindCustomerByUidHandler),
                         MethodName = nameof(HandleAsync)
                     }));

            if (!Guid.TryParse(query.Uid, out var result) && result == Guid.Empty)
            {
                _notificationContext.AddNotification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.QueryIsNotValid);
                return null;
            }

            var customer = await _customerRepository.GetByUidAsync(Guid.Parse(query.Uid));

            if (customer == null) return null;


            return BuildCustomerResponse.Create(customer);
        }
    }
}
