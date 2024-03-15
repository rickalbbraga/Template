using API.Controllers.V1.Public.Customer;
using Application.Commands.Customer;
using Application.Responses.Customer;
using Application.Responses;
using Domain.Interfaces.CQS;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.V1.Public.Customer
{
    public class UpdateCustomerEndpoint(
        ICommandHandlerWithTResult<UpdateCustomerCommand, CustomerResponse> commandHandler) : CustomerController
    {
        private readonly ICommandHandlerWithTResult<UpdateCustomerCommand, CustomerResponse> _commandHandler = commandHandler;

        /// <summary>
        /// Altera um cliente.
        /// </summary>
        /// <param name="uid">Uid do cliente</param>
        /// <param name="updateClientCommand"></param>
        /// <response code="200">Retorna cliente atualizado</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Interanl Server Error</response>
        [HttpPut]
        [Tags("Cliente")]
        [Route("{uid}")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(CustomerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(IEnumerable<ErrorResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, type: typeof(ErrorResponse))]
        public async Task<IActionResult> PutAsync([FromRoute] string uid, [FromBody] UpdateCustomerCommand updateClientCommand)
        {
            updateClientCommand.Uid = uid;
            return Ok(await _commandHandler.HandleAsync(updateClientCommand));
        }
    }
}
