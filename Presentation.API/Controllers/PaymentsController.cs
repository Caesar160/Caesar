using Caesar.Application.Aggregates.Products.Commands.BuyProduct;
using Caesar.Application.Aggregates.Products.Queries.GetProductsList;
using Microsoft.AspNetCore.Mvc;

namespace Caesar.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : BaseController
    {
        [HttpPost("/buy")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BuyProductAsync([FromBody] BuyProductCommand command)
        {
            await this.Mediator.Send(command);
            return Ok();
        }

        [HttpGet("/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsListAsync([FromQuery] GetProductsListQuery command)
        {
            await this.Mediator.Send(command);
            return Ok();
        }
    }
}
