namespace Caesar.Application.Aggregates.Products.Commands.CreatePayment;

using MediatR;
using Newtonsoft.Json;

public class CreatePaymentCommand : IRequest<Unit>
{
    [JsonProperty("priceId")]
    public string PriceId
    {
        get;
        set;
    }
}
