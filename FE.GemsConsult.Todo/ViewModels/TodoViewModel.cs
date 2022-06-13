using Project.Service.Models.Responses;

namespace FE.GemsConsult.Todo.ViewModels
{
    public class TodoViewModel
    {
        public CreateTodoItemViewModel AddItem { get; set; }
        public AllTodoItemResponse AllTodoItems { get; set; }

        public TodoViewModel()
        {
            AddItem = new CreateTodoItemViewModel();
            AllTodoItems = new AllTodoItemResponse();
        }
    }

    public class ExtendedResponse : AllTodoItemResponse
    {
        public CreateTodoItemViewModel AddItem { get; set; }
    }
}
