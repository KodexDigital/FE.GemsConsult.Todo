using System.Text.Json.Serialization;

namespace Project.Service.Models.Requests
{
    public class EditItemRequest
    {
        [JsonPropertyName("itemName")]
        public string ItemName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("executionDate")]
        public DateTime ExecutionDate { get; set; }

        [JsonPropertyName("itemId")]
        public int ItemId { get; set; }
    }
}
