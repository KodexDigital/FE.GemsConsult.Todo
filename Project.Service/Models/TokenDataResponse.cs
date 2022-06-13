using System.Text.Json.Serialization;

namespace Project.Service.Models
{
    public class TokenDataResponse
    {
        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonPropertyName("applicationUserName")]
        public string Name { get; set; }
    }
}
