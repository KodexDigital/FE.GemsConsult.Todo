using System.Text.Json.Serialization;

namespace Project.Service.Models.Requests
{
    public class AddItemRequest
    {
        [JsonPropertyName("itemName")]
        public string ItemName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("executionDate")]
        public DateTime ExecutionDate { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }
    }
}
