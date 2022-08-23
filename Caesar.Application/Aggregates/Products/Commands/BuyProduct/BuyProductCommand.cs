using MediatR;
using Newtonsoft.Json;

namespace Caesar.Application.Aggregates.Products.Commands.BuyProduct
{
    public class BuyProductCommand : IRequest<Unit>
    {
        [JsonProperty("id")]
        public int Id
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

        [JsonProperty("active")]
        public bool Active
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
}
