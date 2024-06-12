using Newtonsoft.Json;

namespace Restcountries_api.Models
{
    public class CountryDetailInfo
    {
        [JsonProperty("name")]
        public NameDetail Name { get; set; } 

        public class NameDetail
        {
            [JsonProperty("common")]
            public string Common { get; set; }
        }

        [JsonProperty("capital")]
        public List<string>? Capitals { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("languages")]
        public Dictionary<string, string>? Languages { get; set; }
    }
}
