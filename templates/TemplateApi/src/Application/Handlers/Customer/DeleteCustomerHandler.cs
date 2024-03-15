using Application.Commands.Customer;
using Domain.Interfaces.CQS;
using Domain.Interfaces.Repositories;
using Domain.Utils.ErrorMessages;
using Semear.Context.CommonCore.DomainNotification;
using Semear.Context.Logger.Interfaces;
using System.Text.Json;

namespace Application.Handlers.Customer
{
    public class DeleteCustomerHandler(
        ICustomerRepository customerRepository,
        ISemearLogService logger,
        INotificationContext notificationContext) : ICommandHandlerWithVoidTResult<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly ISemearLogService _logger = logger;
        private readonly INotificationContext _notificationContext = notificationContext;

        public async Task HandleAsync(DeleteCustomerCommand command)
        {
            _logger.WriteLogInformation(
                JsonSerializer.Serialize(
                    new
                    {
                        Message = "Request Received",
                        Command = command,
                        ClassName = nameof(DeleteCustomerHandler),
                        MethodName = nameof(HandleAsync)
                    }));

            if (!Guid.TryParse(command.Uid, out var result) && result == Guid.Empty)
            {
                _notificationContext.AddNotification(40000, DomainErrorMessages.BadRequest, DomainErrorMessages.CommandIsNotValid);
                return;
            }

            await _customerRepository.DeleteAsync(Guid.Parse(command.Uid));
        }
    }
}
