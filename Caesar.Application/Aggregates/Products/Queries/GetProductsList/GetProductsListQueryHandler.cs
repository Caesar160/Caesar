using Caesar.Settings;
using MediatR;
using Microsoft.Extensions.Options;
using Stripe;
using Caesar.Application.Models;

namespace Caesar.Application.Aggregates.Products.Queries.GetProductsList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, IList<Item>>
    {
        private readonly StripeSettings stripeSettings;

        public GetProductsListQueryHandler(IOptions<StripeSettings> stripeSettings)
        {
            this.stripeSettings = stripeSettings.Value;
        }

        public async Task<IList<Item>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            StripeConfiguration.ApiKey = stripeSettings.PublishableKey;
            var options = new ProductListOptions
            {
                Limit = 3,
            };
            var service = new ProductService();
            StripeList<Product> stripeProducts = service.List(
              options);
            var products = new List<Item>();
            foreach(var stripeProduct in stripeProducts)
            {
                products.Add(new Item
                {
                    Id = stripeProduct.Id,
                    Name = stripeProduct.Name,
                    Description = stripeProduct.Description,
                    Active = stripeProduct.Active
                }) ;
            }
            return products;
        }
    }
}
