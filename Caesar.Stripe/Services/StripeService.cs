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
        var customer = service.SearchAsync(searchOptions);
        var result = customer.Result.Data.FirstOrDefault();
        return result;
    }
    public async Task<Customer> GetCustomerByIdAsync(string id)
    {
        var service = new CustomerService();
        var searchOptions = new CustomerSearchOptions { Query = $"Id:'{id}'" };
        var customer = await service.SearchAsync(searchOptions);
        return customer.Data.FirstOrDefault()!;
    }

    public async Task<Price> SearchPriceForProductAsync(string productId)
    {
        var options = new PriceSearchOptions
        {
            Query = $"product: '{productId}'",
        };
        var service = new PriceService();
        var result = service.Search(options).Data.First();
        return result;
    }
}
