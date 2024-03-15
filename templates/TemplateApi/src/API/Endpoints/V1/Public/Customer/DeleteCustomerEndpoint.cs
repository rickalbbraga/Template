using API.Controllers.V1.Public.Customer;
using Application.Commands.Customer;
using Application.Responses;
using Domain.Interfaces.CQS;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.V1.Public.Customer
{
    public class DeleteCustomerEndpoint(
        ICommandHandlerWithVoidTResult<DeleteCustomerCommand> commandHandler) : CustomerController
    {
        private readonly ICommandHandlerWithVoidTResult<DeleteCustomerCommand> _commandHandler = commandHandler;

        /// <summary>
        /// Remove um cliente.
        /// </summary>
        /// <param name="uid">Uid do Cliente</param>
        /// <response code="204">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Interanl Server Error</response>
        [HttpDelete]
        [Route("{uid}")]
        [Tags("Cliente")]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(IEnumerable<ErrorResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, type: typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteAsync([FromRoute] string uid)
        {
            await _commandHandler.HandleAsync(new DeleteCustomerCommand { Uid = uid });
            return NoContent();
        }
    }
}
