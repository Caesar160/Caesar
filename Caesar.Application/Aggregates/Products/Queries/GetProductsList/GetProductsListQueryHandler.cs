﻿namespace Caesar.Application.Aggregates.Products.Queries.GetProductsList
{
    using Interfaces;
    using MediatR;
    using Stripe;

    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<Product>>
    {
        private readonly IStripeService _stripeService;

        public GetProductsListQueryHandler(IStripeService stripeService)
        {
            _stripeService = stripeService;
        }

        public async Task<List<Product>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = _stripeService.GetProductsList();
            return await products;
        }
    }
}
