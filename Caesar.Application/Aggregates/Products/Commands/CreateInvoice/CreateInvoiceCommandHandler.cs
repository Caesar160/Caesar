namespace Caesar.Application.Aggregates.Products.Commands.CreateInvoice;

using BuyProduct;
using MediatR;

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Unit>
{
    public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        return Unit.Value;
    }
}
