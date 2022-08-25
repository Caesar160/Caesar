namespace Caesar.Application.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Stripe;

    public interface IStripeService
    {
        Task<List<Product>> GetProductsList();
        Task CreateCustomer(string name, string description, string phone, string email);
    }
}
