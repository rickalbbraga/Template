using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1.Public.Customer
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/public/customers")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class CustomerController : ControllerBase
    {
    }
}
