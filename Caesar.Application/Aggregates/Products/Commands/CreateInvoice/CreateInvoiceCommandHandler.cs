namespace Caesar.Application.Aggregates.Products.Commands.CreateInvoice
{
    using System.Threading;
    using System.Threading.Tasks;
    using BuyProduct;
    using MediatR;

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Unit>
    {

        public CreateInvoiceCommandHandler()
        {
        }
        public async Task<Unit> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}

