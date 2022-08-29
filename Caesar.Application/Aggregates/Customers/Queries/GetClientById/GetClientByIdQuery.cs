namespace Caesar.Application.Aggregates.Customers.Queries.GetClientById;

using MediatR;
using Models;

public class GetClientByIdQuery : IRequest<Customer>
{
    public GetClientByIdQuery(long id)
    {
        this.Id = id;
    }

    public long Id
    {
        get;
    }
}
