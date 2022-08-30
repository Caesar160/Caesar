namespace Caesar.Application.Aggregates.Products.Commands.CreatePayment;

using Caesar.Application.Interfaces;
using MediatR;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Unit>
{
    private readonly IStripeService _stripeService;

    public CreatePaymentCommandHandler(IStripeService stripeService)
    {
        this._stripeService = stripeService;
        
    }
    public async Task<Unit> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        await this._stripeService.CreatePayment(request.PriceId);
        return Unit.Value;
    }
}
