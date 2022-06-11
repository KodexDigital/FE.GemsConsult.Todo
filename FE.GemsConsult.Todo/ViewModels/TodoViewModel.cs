namespace FE.GemsConsult.Todo.ViewModels
{
    public class TodoViewModel
    {
        public CreateTodoItemViewModel AddItem { get; set; }
        public IEnumerable<AllTodoItmeViewModel> AllTodoItmes { get; set; }

        public TodoViewModel()
        {
            AddItem = new CreateTodoItemViewModel();
            AllTodoItmes = new List<AllTodoItmeViewModel>();
        }
    }
}
