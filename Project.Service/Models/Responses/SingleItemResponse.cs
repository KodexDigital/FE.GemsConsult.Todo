using System.Text.Json.Serialization;

namespace Project.Service.Models.Responses
{
    public class SingleItemResponse : BaseResponse
    {
        [JsonPropertyName("data")]
        public ItemData Data { get; set; }
    }


    public class ItemData
    {
        [JsonPropertyName("todoId")]
        public int TodoId { get; set; }

        [JsonPropertyName("itemName")]
        public string ItemName { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("executionDate")]
        public DateTime ExecutionDate { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("isExecuted")]
        public bool IsExecuted { get; set; }

        [JsonPropertyName("remove")]
        public bool Remove { get; set; }

        [JsonPropertyName("applicationUserId")]
        public string ApplicationUserId { get; set; }

        [JsonPropertyName("applicationUser")]
        public object ApplicationUser { get; set; }
    }
}
