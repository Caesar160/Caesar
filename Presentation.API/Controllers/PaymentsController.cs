namespace Caesar.Presentation.API.Controllers;

using Application.Aggregates.Products.Commands.CreatePaidProduct;
using Application.Aggregates.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PaymentsController : BaseController
{
    [HttpGet("/list")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductsListAsync()
    {
        var result = await this.Mediator.Send(new GetProductsListQuery());
        return this.Ok(result);
    }

    [HttpPost("/checkout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateCheckoutSessionAsync([FromBody] CreateCheckoutSessionCommand command)
    {
        var result = await this.Mediator.Send(command);
        return this.Ok(result);
    }
}
