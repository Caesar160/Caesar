using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Caesar.Application.Aggregates.Products.Commands.BuyProduct
{
    public class BuyProductCommandHandler : IRequestHandler<BuyProductCommand, Unit>
    {

        public BuyProductCommandHandler()
        {
        }
        public async Task<Unit> Handle(BuyProductCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}

