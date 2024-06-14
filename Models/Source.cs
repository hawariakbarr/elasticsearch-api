using System.Text.Json.Serialization;

namespace ElasticsearchApi.Models
{
    public class Source
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("deceased")]
        public string Deceased { get; set; }

        [JsonPropertyName("occupation")]
        public string Occupation { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("person_entity_id")]
        public int PersonEntityId { get; set; }

        [JsonPropertyName("watchlist_info")]
        public string WatchlistInfo { get; set; }

        [JsonPropertyName("name_category")]
        public string NameCategory { get; set; }

        [JsonPropertyName("relation")]
        public string Relation { get; set; }

        [JsonPropertyName("dob_pob")]
        public string DobPob { get; set; }

        [JsonPropertyName("person_status")]
        public string PersonStatus { get; set; }

        [JsonPropertyName("action")]
        public string Action { get; set; }
    }
}
