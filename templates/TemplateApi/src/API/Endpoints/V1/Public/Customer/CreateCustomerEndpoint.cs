using API.Controllers.V1.Public.Customer;
using Application.Commands.Customer;
using Application.Responses.Customer;
using Application.Responses;
using Domain.Interfaces.CQS;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.V1.Public.Customer
{
    public class CreateCustomerEndpoint(
        ICommandHandlerWithTResult<CreateCustomerCommand, CustomerResponse> commandHandler) : CustomerController
    {
        private readonly ICommandHandlerWithTResult<CreateCustomerCommand, CustomerResponse> _commandHandler = commandHandler;

        /// <summary>
        /// Cria um cliente.
        /// </summary>
        /// <param name="createCustomerCommand"></param>
        /// <response code="201">Retorna cliente criado</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Interanl Server Error</response>
        [HttpPost]
        [Tags("Cliente")]
        [SwaggerResponse(StatusCodes.Status201Created, type: typeof(CustomerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(IEnumerable<ErrorResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, type: typeof(ErrorResponse))]
        public async Task<IActionResult> PostAsync([FromBody] CreateCustomerCommand createCustomerCommand)
        {
            return Created(string.Empty, await _commandHandler.HandleAsync(createCustomerCommand));
        }
    }
}
