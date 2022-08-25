namespace Caesar.Application.Aggregates.Customers.Commands.SignUp
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Caesar.Application.Interfaces;
    using Caesar.Application.Models;
    //using AutoMapper;
    using Caesar.Settings;
    using MediatR;
    using Microsoft.Extensions.Options;
    using Stripe;

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
    {
        private IMapper _mapper;
        private readonly IStripeService _stripeService;

        public CreateCustomerCommandHandler(IStripeService stripeService, IMapper mapper)
        {
            _stripeService = stripeService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _stripeService.CreateCustomer(request.Name, request.Description, request.Phone, request.Email);
            return Unit.Value;
        }
    }
}
