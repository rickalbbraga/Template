using Application.Commands.Customer;
using Application.Helpers.Builders;
using Application.Responses.Customer;
using Domain.Interfaces.CQS;
using Domain.Interfaces.Repositories;
using Semear.Context.CommonCore.DomainNotification;
using Semear.Context.Logger.Interfaces;
using System.Text.Json;

namespace Application.Handlers.Customer
{
    public class CreateCustomerHandler(
        ISemearLogService logger,
        INotificationContext notificationContext,
        ICustomerRepository customerRepository) : ICommandHandlerWithTResult<CreateCustomerCommand, CustomerResponse>
    {
        private readonly ISemearLogService _logger = logger;
        private readonly INotificationContext _notificationContext = notificationContext;
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public async Task<CustomerResponse?> HandleAsync(CreateCustomerCommand command)
        {
            _logger.WriteLogInformation(
                JsonSerializer.Serialize(
                    new
                    {
                        Message = "Request Received",
                        Command = command,
                        ClassName = nameof(CreateCustomerHandler),
                        MethodName = nameof(HandleAsync)
                    }));

            var customer = Domain.Entities.Customer.Create(command.Name, command.Document, command.Email);

            _notificationContext.AddNotifications(customer);

            if (_notificationContext.HasNotifications) return null;

            await _customerRepository.AddAsync(customer);

            return BuildCustomerResponse.Create(customer);
        }
    }
}
