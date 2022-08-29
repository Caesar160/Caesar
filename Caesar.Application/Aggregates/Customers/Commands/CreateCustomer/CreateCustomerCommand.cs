namespace Caesar.Application.Aggregates.Customers.Commands.CreateCustomer;

using Caesar.Application.Mappings;
using Caesar.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

public class CreateCustomerCommand : IRequest<long>, IMapTo<User>

{
    [JsonProperty("name")]
    public string Name
    {
        get;
        set;
    }

    [JsonProperty("phone")]
    public string Phone
    {
        get;
        set;
    }

    [JsonProperty("description")]
    public string Description
    {
        get;
        set;
    }

    [JsonProperty("email")]
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
