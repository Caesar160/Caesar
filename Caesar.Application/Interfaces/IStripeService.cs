namespace Caesar.Application.Interfaces;

using Stripe;

public interface IStripeService
{
    Task<List<Product>> GetProductsList();
    Task<Customer> CreateCustomerAsync(string name, string description, string phone, string email);
    Task UpdateCustomer(string id, string name, string description);
    Task<Customer> GetCustomerByEmailAsync(string email);
    Task CreatePayment(string priceId);
}
