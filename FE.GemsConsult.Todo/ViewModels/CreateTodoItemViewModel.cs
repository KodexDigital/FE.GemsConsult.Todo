using Project.Service.Models.Requests;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FE.GemsConsult.Todo.ViewModels
{
    public class CreateTodoItemViewModel
    {
        [Required(ErrorMessage ="Item name required.")]
        [Display(Name = "Item name")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Description required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Execution date required.")]
        [Display(Name = "Execution date")]
        [DataType(DataType.Date)]
        public DateTime ExecutionDate { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
