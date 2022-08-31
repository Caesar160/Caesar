namespace Caesar.Application.Aggregates.Products.Commands.CreatePaidProduct;

using Interfaces;
using MediatR;
using Stripe.Checkout;

public class CreatePaidProductCommandHandler : IRequestHandler<CreatePaidProductCommand, Unit>
{
    private readonly IStripeService _stripeService;
    private readonly ICaesarDbContext _caesarDbContext;
    private readonly long userId;

    public CreatePaidProductCommandHandler(IStripeService stripeService, ICaesarDbContext caesarDbContext, ICurrentUserService currentUser)
    {
        this._stripeService = stripeService;
        this._caesarDbContext = caesarDbContext;
        this.userId = currentUser.UserId;
    }

    public async Task<Unit> Handle(CreatePaidProductCommand request, CancellationToken cancellationToken)
    {
        var options = new SessionGetOptions();
        options.AddExpand("line_items");
        var service = new SessionService();
        Session session = service.Get($"{request.sessionId}", options);
        var email = session.CustomerDetails.Email;
        var user = this._stripeService.GetCustomerByEmailAsync(email).Result;
        var item = session.LineItems.Data.FirstOrDefault();
        var product = new Domain.Entities.Product()
        {
            CustomerStripeId = user.Id,
            Description = item.Description,
            Paid = true,
            PriceId = session.LineItems.First().Price.Id,
            StripeId = item.Price.ProductId
        };
        this._caesarDbContext.Products.Add(product);
        await this._caesarDbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
