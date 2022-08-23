using Caesar.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar.Application.Aggregates.Products.Queries.GetProductsList
{
    public class GetProductsListQuery : IRequest<IList<Item>>
    {
    }
}
