namespace Caesar.Stripe.Services
{
    using Application.Interfaces;
    using AutoMapper;
    using Caesar.Settings;
    using global::Stripe;
    using Microsoft.Extensions.Options;

    public class StripeService : IStripeService
    {
        private readonly StripeSettings _stripeSettings;
        private readonly IMapper _mapper;
        public StripeService(IMapper mapper, IOptions<StripeSettings> stripeSettings)
        {
            _mapper = mapper;
            _stripeSettings = stripeSettings.Value;
            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
        }
        public async Task<List<Product>> GetProductsList()
        {
            var service = new ProductService();
            StripeList<Product> stripeProducts = await service.ListAsync();
            var products = _mapper.Map<List<Product>>(stripeProducts);
            return products;
        }

        public async Task CreateCustomer(string name, string description, string phone, string email)
        {
            var options = new CustomerCreateOptions()
            {
                Name = name,
                Description = description,
                Phone = phone,
                Email = email
            };
            await new CustomerService().CreateAsync(options);
        }
    }
}
