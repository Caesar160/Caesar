namespace Caesar.Application.Aggregates.Customers.Commands.ChangePassword;

using MediatR;
using Newtonsoft.Json;

public class ChangePasswordCommand : IRequest<Unit>
{
    [JsonProperty("oldPassword")]
    public string OldPassword
    {
        get; set;
    }

    [JsonProperty("password")]
    public string Password
    {
        get; set;
    }

    [JsonProperty("confirm")]
    public string Confirm
    {
        get; set;
    }
}
