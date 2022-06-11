using Microsoft.AspNetCore.Mvc;

namespace FE.GemsConsult.Todo.Controllers
{
    public class TodoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
