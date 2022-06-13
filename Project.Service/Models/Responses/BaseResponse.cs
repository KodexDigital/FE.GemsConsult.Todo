using System.Text.Json.Serialization;

namespace Project.Service.Models.Responses
{
    public class BaseResponse
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }


    public class LoginData
    {
        [JsonPropertyName("token")]
        public LoginToken Token { get; set; }
    }

    public class LoginResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public LoginData Data { get; set; }
    }

    public class LoginToken
    {
        [JsonPropertyName("tokenValue")]
        public string TokenValue { get; set; }
    }
}
