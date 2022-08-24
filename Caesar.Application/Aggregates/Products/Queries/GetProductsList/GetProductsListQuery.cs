namespace Caesar.Application.Aggregates.Products.Queries.GetProductsList
{
    using Caesar.Application.Models;
    using MediatR;
    using System.Collections.Generic;

    public class GetProductsListQuery : IRequest<IList<Item>>
    {
    }
}
