namespace Caesar.Application.Aggregates.Customers.Commands.CreateCustomer;

using AutoMapper;
using Mappings;
using Domain.Entities;
using Common.Helpers;
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

    [JsonProperty("password")]
    public string Password
    {
        get;
        set;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCustomerCommand, User>()
            .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.Phone.Trim().ToLower()))
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email.Trim().ToLower()))
            .ForMember(d => d.Password, opt => opt.MapFrom(s => CryptoHelper.HashPassword(s.Password)));
    }
}
