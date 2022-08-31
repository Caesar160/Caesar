namespace Caesar.Application.Aggregates.Customers.Commands.UpdateCustomer;

using Mappings;
using Domain.Entities;
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

    public void Mapping(AutoMapper.Profile profile)
    {
        profile.CreateMap<UpdateCustomerCommand, User>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
    }
}
