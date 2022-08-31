namespace Caesar.Presentation.API.Controllers
{
    using Application.Aggregates.Products.Commands.CreatePaidProduct;
    using global::Stripe;
    using global::Stripe.Checkout;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class StripeWebHook : BaseController
    {
        [HttpPost("/webhook")]
        public async Task<IActionResult> Index()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var stripeEvent = EventUtility.ParseEvent(json);
            try
            {
                if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                {
                    var session = stripeEvent.Data.Object as Session;
                    var command = new CreatePaidProductCommand
                    {
                        sessionId = session.Id
                    };
                    await this.Mediator.Send(command);
                    return this.Ok();
                }

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }

    }
}

