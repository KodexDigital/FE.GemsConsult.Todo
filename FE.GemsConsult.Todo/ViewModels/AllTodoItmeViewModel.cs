namespace FE.GemsConsult.Todo.ViewModels
{
    public class AllTodoItmeViewModel
    {
        public int TodoId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsExecuted { get; set; }
        public bool Remove { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
