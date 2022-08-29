namespace Caesar.Application.Models;

using Newtonsoft.Json;

public class Customer
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
}
