using System.Text.Json.Serialization;

namespace ElasticsearchApi.Models
{
    public class RequestData
    {
        [JsonPropertyName("req_id")]
        public string ReqId { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("town")]
        public string Town { get; set; }

        [JsonPropertyName("h_countryflag")]
        public string HCountryflag { get; set; }

        [JsonPropertyName("birthdate")]
        public string Birthdate { get; set; }

        [JsonPropertyName("nat_countryflag")]
        public string NatCountryflag { get; set; }

        [JsonPropertyName("pass_no")]
        public string PassNo { get; set; }

        [JsonPropertyName("birth_country")]
        public string BirthCountry { get; set; }

        [JsonPropertyName("birth_place")]
        public string BirthPlace { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }
    }
}
