namespace Caesar.Presentation.API.Controllers;

using Application.Aggregates.Customers.Commands.CreateCustomer;
using Application.Aggregates.Customers.Commands.UpdateCustomer;
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
        return this.Ok();
    }

    [HttpPut("/update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCustomerCommand command)
    {
        await this.Mediator.Send(command);
        return this.Ok();
    }
}
