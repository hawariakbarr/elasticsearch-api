using ElasticsearchApi.Controllers;
using System.Text.Json.Serialization;

namespace ElasticsearchApi.Models
{
    public class SampleDocument 
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("_source")]
        public Source Source { get; set; }

        [JsonPropertyName("fields")]
        public Fields Fields { get; set; }
    }
}
