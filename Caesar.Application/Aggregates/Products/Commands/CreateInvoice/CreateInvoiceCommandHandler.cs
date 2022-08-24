using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Caesar.Application.Aggregates.Products.Commands.BuyProduct
{
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

