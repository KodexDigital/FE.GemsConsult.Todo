using System.ComponentModel.DataAnnotations;

namespace FE.GemsConsult.Todo.ViewModels
{
    public class EditItemViewModel
    {
        [Display(Name = "Item name")]
        public string ItemName { get; set; }
        public string Description { get; set; }

        [Display(Name = "Execution date")]
        public DateTime ExecutionDate { get; set; }
        public int ItemId { get; set; }
    }
}
