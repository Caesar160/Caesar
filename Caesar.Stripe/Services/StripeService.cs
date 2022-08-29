namespace Caesar.Stripe.Services;

using Application.Interfaces;
using AutoMapper;
using global::Stripe;
using Microsoft.Extensions.Options;
using Settings;

public class StripeService : IStripeService
{
    private readonly IMapper _mapper;
    private readonly StripeSettings _stripeSettings;

    public StripeService(IMapper mapper, IOptions<StripeSettings> stripeSettings)
    {
        this._mapper = mapper;
        this._stripeSettings = stripeSettings.Value;
        StripeConfiguration.ApiKey = this._stripeSettings.SecretKey;
    }

    public async Task<List<Product>> GetProductsList()
    {
        var service = new ProductService();
        StripeList<Product> stripeProducts = await service.ListAsync();
        var products = this._mapper.Map<List<Product>>(stripeProducts);
        return products;
    }

    public async Task CreateCustomer(string name, string description, string phone, string email)
    {
        var options = new CustomerCreateOptions {Name = name, Description = description, Phone = phone, Email = email};
        await new CustomerService().CreateAsync(options);
    }
}
