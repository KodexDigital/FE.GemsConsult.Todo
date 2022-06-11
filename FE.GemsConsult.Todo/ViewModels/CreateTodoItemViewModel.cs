using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FE.GemsConsult.Todo.ViewModels
{
    public class CreateTodoItemViewModel
    {
        [JsonPropertyName("itemName")]
        [Required(ErrorMessage ="Item name required.")]
        [Display(Name = "Item name")]
        public string ItemName { get; set; }

        [JsonPropertyName("description")]
        [Required(ErrorMessage = "Description required.")]
        public string Description { get; set; }

        [JsonPropertyName("executionDate")]
        [Required(ErrorMessage = "Execution date required.")]
        [Display(Name = "Execution date")]
        [DataType(DataType.Date)]
        public DateTime ExecutionDate { get; set; }

        [JsonPropertyName("userId")]
        [Required]
        public string UserId { get; set; }
    }
}
