namespace Caesar.Application.Aggregates.Products.Queries.GetProductsList
{
    using Caesar.Settings;
    using MediatR;
    using Microsoft.Extensions.Options;
    using Stripe;
    using Caesar.Application.Models;
    using AutoMapper;
    using System.Collections.Generic;

    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, IList<Item>>
    {
        private readonly StripeSettings stripeSettings;
        private IMapper mapper;

        public GetProductsListQueryHandler(IOptions<StripeSettings> stripeSettings, IMapper mapper)
        {
            this.stripeSettings = stripeSettings.Value;
            this.mapper = mapper;
        }

        public async Task<IList<Item>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            StripeConfiguration.ApiKey = stripeSettings.SecretKey;
            var service = new ProductService();
            StripeList<Product> stripeProducts = service.List();
            var products = mapper.Map<List<Item>>(stripeProducts.Data);
            return products;
        }
    }
}
