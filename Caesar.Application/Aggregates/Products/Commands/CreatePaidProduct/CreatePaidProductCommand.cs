namespace Caesar.Application.Aggregates.Products.Commands.CreatePaidProduct;

using MediatR;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;

public class CreatePaidProductCommand : IRequest<Unit>
{
    [JsonProperty("sessionId")]
    public string sessionId
    {
        get;
        set;
    }
}
