namespace Caesar.Application.Aggregates.Customers.Commands.SignUp
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Caesar.Settings;
    using MediatR;
    using Microsoft.Extensions.Options;
    using Stripe;

    public class SignUpCustomerCommandHandler : IRequestHandler<SignUpCustomerCommand, Unit>
    {
        private readonly StripeSettings stripeSettings;
        private IMapper mapper;

        public SignUpCustomerCommandHandler(IOptions<StripeSettings> stripeSettings, IMapper mapper)
        {
            this.stripeSettings = stripeSettings.Value;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(SignUpCustomerCommand request, CancellationToken cancellationToken)
        {
            StripeConfiguration.ApiKey = stripeSettings.SecretKey;
            var options = mapper.Map<CustomerCreateOptions>(request);
            new CustomerService().Create(options);
            return Unit.Value;
        }
    }
}
