namespace Caesar.Presentation.API.Controllers
{
    using Application.Aggregates.Products.Commands.BuyProduct;
    using Caesar.Application.Aggregates.Products.Queries.GetProductsList;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseController
    {
        [HttpPost("/buy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateInvoiceAsync([FromBody] CreateInvoiceCommand command)
        {
            await this.Mediator.Send(command);
            return Ok();
        }

        [HttpGet("/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsListAsync()
        {
            var result = await this.Mediator.Send(new GetProductsListQuery());
            return Ok(result);
        }
    }
}
