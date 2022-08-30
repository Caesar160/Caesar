namespace Caesar.Stripe.Services;

using Application.Interfaces;
using AutoMapper;
using global::Stripe;
using global::Stripe.Checkout;
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

    public async Task<Customer> CreateCustomerAsync(string name, string description, string phone, string email)
    {
        var options = new CustomerCreateOptions {Name = name, Description = description, Phone = phone, Email = email};
        var customerService = new CustomerService();
        var created = await customerService.CreateAsync(options);
        return created;
    }

    public async Task UpdateCustomer(string id, string name, string description)
    {
        var options = new CustomerUpdateOptions
        {
            Name = name,
            Description = description
        };
        var service = new CustomerService();
        await new CustomerService().UpdateAsync(id, options);
    }

    public async Task<Customer> GetCustomerByEmailAsync(string email)
    {
        var service = new CustomerService();
        var searchOptions = new CustomerSearchOptions { Query = $"email:'{email}'" };
        var customer = await service.SearchAsync(searchOptions);
        return customer.Data.FirstOrDefault()!;
    }

    public async Task CreatePayment(string priceId)
    {
        var options = new SessionCreateOptions
        {
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    Price = $"{priceId}",
                    Quantity = 1,
                },
            },
            Mode = "payment"
        };
        var service = new SessionService();
        await service.CreateAsync(options);
    }
}
