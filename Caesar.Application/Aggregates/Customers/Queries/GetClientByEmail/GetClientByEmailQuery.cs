namespace Caesar.Application.Aggregates.Customers.Queries.GetClientByEmail;

using MediatR;
using Models;

public class GetClientByEmailQuery : IRequest<Customer>
{
    public string Email
    {
        get;
        set;
    }

    public string Password
    {
        get;
        set;
    }
}
