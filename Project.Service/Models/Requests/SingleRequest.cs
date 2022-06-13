using System.Text.Json.Serialization;

namespace Project.Service.Models.Requests
{
    public class SingleRequest
    {
        [JsonPropertyName("itemId")]
        public int ItemId { get; set; }
    }
}
