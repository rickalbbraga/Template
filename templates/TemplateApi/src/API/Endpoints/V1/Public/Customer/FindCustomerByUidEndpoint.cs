using API.Controllers.V1.Public.Customer;
using Application.Queries.Customer;
using Application.Responses.Customer;
using Application.Responses;
using Domain.Interfaces.CQS;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Endpoints.V1.Public.Customer
{
    public class FindCustomerByUidEndpoint(
        IQueryHandlerWithTResult<FindCustomerByUidQuery, CustomerResponse> queryHandler) : CustomerController
    {
        private readonly IQueryHandlerWithTResult<FindCustomerByUidQuery, CustomerResponse> _queryHandler = queryHandler;

        /// <summary>
        /// Busca um cliente pelo uid.
        /// </summary>
        /// <param name="uid"></param>
        /// <response code="200">Retorna o cliente pelo Id</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Interanl Server Error</response>
        [HttpGet]
        [Route("{uid}")]
        [Tags("Cliente")]
        [SwaggerResponse(StatusCodes.Status200OK, type: typeof(CustomerResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, type: typeof(IEnumerable<ErrorResponse>))]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, type: typeof(ErrorResponse))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] string uid)
        {
            return Ok(await _queryHandler.HandleAsync(new FindCustomerByUidQuery { Uid = uid}));
        }
    }
}
