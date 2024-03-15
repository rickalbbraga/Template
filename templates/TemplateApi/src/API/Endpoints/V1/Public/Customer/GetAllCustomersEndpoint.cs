using API.Controllers.V1.Public.Customer;
using Application.Queries.Customer;
using Application.Responses.Customer;
using Application.Responses;
using Domain.Interfaces.CQS;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.V1.Public.Customer
{
    public class GetAllCustomersEndpoint(
        IQueryHandlerWithTResultList<GetAllCustomerQuery, CustomerResponse> queryHandler) : CustomerController
    {
        private readonly IQueryHandlerWithTResultList<GetAllCustomerQuery, CustomerResponse> _queryHandler = queryHandler;

        /// <summary>
        /// Busca todos os clientes.
        /// </summary>
        /// <response code="200">Retorna lista de clientes</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Interanl Server Error</response>
        [HttpGet]
        [Tags("Cliente")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(IEnumerable<CustomerResponse>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(IEnumerable<ErrorResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, type: typeof(ErrorResponse))]
        public async Task<IActionResult> GetAllAsync([FromQuery] GetAllCustomerQuery getAllCustomerQuery)
        {
            return Ok(await _queryHandler.HandleAsync(getAllCustomerQuery));
        }
    }
}
