using System.Text.Json.Serialization;

namespace ElasticsearchApi.Models
{
    public class SearchRequestModel
    {
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("data_source")]
        public string DataSource { get; set; }

        [JsonPropertyName("data")]
        public RequestData[] Data { get; set; }
    }
}
