namespace Caesar.Application.Aggregates.Products.Commands.CreatePaidProduct;

using MediatR;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;

public class CreateCheckoutSessionCommand : IRequest<string>
{
    [JsonProperty("productId")]
    public string ProductId
    {
        get;
        set;
    }

    [JsonProperty("quantity")]
    public long Quantity
    {
        get;
        set;
    }
}
