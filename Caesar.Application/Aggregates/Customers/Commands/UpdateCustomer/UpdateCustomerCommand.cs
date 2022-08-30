namespace Caesar.Application.Aggregates.Customers.Commands.UpdateCustomer;

using Caesar.Application.Mappings;
using Caesar.Domain.Entities;
using MediatR;
using Newtonsoft.Json;

public class UpdateCustomerCommand : IRequest<long>, IMapTo<User>

{
    [JsonProperty("name")]
    public string Name
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
}
