using Newtonsoft.Json;

namespace Caesar.Application.Models
{
    public class Item
    {
        [JsonProperty("id")]
        public string Id 
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
