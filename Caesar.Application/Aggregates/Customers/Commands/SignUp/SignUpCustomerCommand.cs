namespace Caesar.Application.Aggregates.Customers.Commands.SignUp
{
    using MediatR;
    using Newtonsoft.Json;

    public class SignUpCustomerCommand : IRequest<Unit>
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
    }
}
