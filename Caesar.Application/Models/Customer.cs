namespace Caesar.Application.Models;

using Domain.Entities;
using Mappings;
using Newtonsoft.Json;

public class Customer : IMapFrom<User>
{
    [JsonProperty("id")]
    public long Id
    {
        get;
        set;
    }

    [JsonProperty("passwordHash")]
    public string PasswordHash
    {
        get;
        set;
    }

    [JsonProperty("role")]
    public string Role
    {
        get;
        set;
    }

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
    public void Mapping(AutoMapper.Profile profile)
    {
        profile.CreateMap<User, Customer>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.PasswordHash, opt => opt.MapFrom(s => s.Password))
            .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Role));
    }
}

