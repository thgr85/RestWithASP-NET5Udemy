using System.Text.Json.Serialization;

namespace RestWithASPNETUdemy.Data.VO
{
    public class PersonVO
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        [JsonIgnore]
        public string? Address { get; set; }
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }
    }
}
