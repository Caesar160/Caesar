namespace Caesar.Presentation.API.Controllers
{
    using Application.Aggregates.Customers.Commands.SignUp;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        [HttpPost("/signup")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> SignUpAsync([FromBody] CreateCustomerCommand command)
        {
            await this.Mediator.Send(command);
            return Ok();
        }
    }
}
