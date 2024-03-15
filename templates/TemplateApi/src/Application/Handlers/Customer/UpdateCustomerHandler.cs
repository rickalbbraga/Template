using Application.Commands.Customer;
using Application.Helpers.Builders;
using Application.Responses.Customer;
using Domain.Interfaces.CQS;
using Domain.Interfaces.Repositories;
using Domain.Utils.ErrorMessages;
using Semear.Context.CommonCore.DomainNotification;
using Semear.Context.Logger.Interfaces;
using System.Text.Json;
using E = Domain.Entities;

namespace Application.Handlers.Customer
{
    public class UpdateCustomerHandler(
        ICustomerRepository customerRepository,
        ISemearLogService logger,
        INotificationContext notificationContext,
        IResponseBuilder<CustomerResponse, E.Customer> responseBuilder) : ICommandHandlerWithTResult<UpdateCustomerCommand, CustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly ISemearLogService _logger = logger;
        private readonly INotificationContext _notificationContext = notificationContext;
        private readonly IResponseBuilder<CustomerResponse, E.Customer> _responseBuilder = responseBuilder;

        public async Task<CustomerResponse?> HandleAsync(UpdateCustomerCommand command)
        {
            _logger.WriteLogInformation(
                JsonSerializer.Serialize(
                    new
                    {
                        Message = "Request Received",
                        Command = command,
                        ClassName = nameof(UpdateCustomerHandler),
                        MethodName = nameof(HandleAsync)
                    }));

            if (!Guid.TryParse(command.Uid, out var result) && result == Guid.Empty)
            {
                _notificationContext.AddNotification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.CommandIsNotValid);
                return null;
            }

            var customer = await _customerRepository.GetByUidAsync(Guid.Parse(command.Uid));

            if (customer == null)
            {
                _notificationContext.AddNotification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.CustomerNotFound);
                return null;
            }

            customer.Update(command.Name, command.Document, command.Email);

            _notificationContext.AddNotifications(customer);

            if (_notificationContext.HasNotifications) return null;

            await _customerRepository.UpdateAsync(customer);

            return _responseBuilder.GetResponse(customer);
        }
    }
}
