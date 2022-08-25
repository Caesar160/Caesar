namespace Caesar.Application.Models
{
    using Newtonsoft.Json;

    public class Customer
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
