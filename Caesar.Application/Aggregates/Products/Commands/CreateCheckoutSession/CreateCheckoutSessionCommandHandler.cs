namespace Caesar.Application.Aggregates.Products.Commands.CreatePaidProduct;

using Interfaces;
using MediatR;
using Stripe.Checkout;

public class CreateCheckoutSessionCommandHandler : IRequestHandler<CreateCheckoutSessionCommand, string>
{
    private readonly IStripeService _stripeService;

    public CreateCheckoutSessionCommandHandler(IStripeService stripeService)
    {
        this._stripeService = stripeService;
    }

    public async Task<string> Handle(CreateCheckoutSessionCommand request, CancellationToken cancellationToken)
    {
        var domain = "http://localhost:44333";
        var price = this._stripeService.SearchPriceForProductAsync(request.ProductId).Result;
        var options = new SessionCreateOptions
        {
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Quantity = request.Quantity,
                    Price = price.Id
                },
            },
            Mode = "payment",
            SuccessUrl = "https://example.com",
            CancelUrl = "https://example.com"
        };
        options.AddExpand("line_items");

        var service = new SessionService();
        Session session = service.Create(options);
        return session.Url;
    }

}
