using System.Text.Json.Serialization;

namespace ElasticsearchApi.Models
{
    public class SearchQuery
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
