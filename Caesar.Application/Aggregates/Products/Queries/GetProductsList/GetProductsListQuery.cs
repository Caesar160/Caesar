namespace Caesar.Application.Aggregates.Products.Queries.GetProductsList
{
    using MediatR;
    using System.Collections.Generic;
    using Stripe;

    public class GetProductsListQuery : IRequest<List<Product>>
    {
    }
}
