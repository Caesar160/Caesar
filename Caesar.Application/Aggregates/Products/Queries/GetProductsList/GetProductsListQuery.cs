namespace Caesar.Application.Aggregates.Products.Queries.GetProductsList;

using MediatR;
using Stripe;

public class GetProductsListQuery : IRequest<List<Product>>
{
}
