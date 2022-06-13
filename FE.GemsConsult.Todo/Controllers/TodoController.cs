using FE.GemsConsult.Todo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Constants;
using Project.Service.Helpers;
using Project.Service.Models.Requests;
using Project.Service.Models.Responses;

namespace FE.GemsConsult.Todo.Controllers
{
    public class TodoController : Controller
    {
        private readonly HttpClientHelper httpClientHelper;
        public TodoController(HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(UserId()))
                return View();

            TodoViewModel vm = new()
            {
                AddItem = new CreateTodoItemViewModel(),
                AllTodoItems = new AllTodoItemResponse()
            };

            var result = await GetAllMyItems();
            if (result.Status.Equals(true))
            {
                vm.AllTodoItems = result;
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(TodoViewModel model)
        {
            TodoViewModel vm = new()
            {
                AddItem = new CreateTodoItemViewModel(),
                AllTodoItems = new AllTodoItemResponse()
            };
            var result = await GetAllMyItems();
            vm.AllTodoItems = result;

            if (!ModelState.IsValid)
                ModelState.AddModelError(string.Empty, "Error encounterer");

            var request = new AddItemRequest
            {
                ItemName = model.AddItem.ItemName,
                ExecutionDate = model.AddItem.ExecutionDate,
                Description = model.AddItem.Description,
                UserId = UserId()
            };
            var response = await httpClientHelper.PostContentAsync<AddItemRequest, BaseResponse>(request, $"{APIRoutes.TodoPath}/addItem", GetUserToken());
            if (response.Status.Equals(true))
            {
                ViewBag.Info = response.Message;
                ViewBag.Status = response.Status;
            }
            else
            {
                ViewBag.Info = response.Message;
                ViewBag.Status = response.Status;
            }

            ModelState.Clear();

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int itemId)
        {
            TodoViewModel vm = new()
            {
                AddItem = new CreateTodoItemViewModel(),
                AllTodoItems = new AllTodoItemResponse()
            };

            var result = await GetAllMyItems();
            vm.AllTodoItems = result;

            SingleRequest request = new()
            {
                ItemId = itemId,
            };
            var response = await httpClientHelper.PostContentAsync<SingleRequest, BaseResponse>(request, $"{APIRoutes.TodoPath}/removeItem/{itemId}", GetUserToken());
            if (response.Status.Equals(true))
            {
                ViewBag.Info = response.Message;
                ViewBag.Status = response.Status;
            }

            return RedirectToAction(nameof(Index));
        } 
        
        [HttpPost]
        public async Task<IActionResult> MarkAsDone(int itemId)
        {
            TodoViewModel vm = new()
            {
                AddItem = new CreateTodoItemViewModel(),
                AllTodoItems = new AllTodoItemResponse()
            };

            var result = await GetAllMyItems();
            vm.AllTodoItems = result;

            SingleRequest request = new()
            {
                ItemId = itemId,
            };
            var response = await httpClientHelper.UpdateAsync<SingleRequest, BaseResponse>(request, $"{APIRoutes.TodoPath}/updateExcutedItem/{itemId}", GetUserToken());
            if (response.Status.Equals(true))
            {
                ViewBag.Info = response.Message;
                ViewBag.Status = response.Status;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditItem(int itemId)
        {
            EditItemViewModel edit = new();

            var response = await GetAnItem(itemId);
            if (response.Status.Equals(true))
            {
                edit.ItemName = response.Data.ItemName;
                edit.ExecutionDate = response.Data.ExecutionDate;
                edit.Description = response.Data.Description;
                edit.ItemId = response.Data.TodoId;
            }
            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> EditItem(EditItemViewModel model)
        {
            EditItemRequest request = new()
            {
                ItemName = model.ItemName,
                ExecutionDate = model.ExecutionDate,
                Description = model.Description,
                ItemId = model.ItemId
            };
            var response = await httpClientHelper.UpdateAsync<EditItemRequest, BaseResponse>(request, $"{APIRoutes.TodoPath}/editItem", GetUserToken());
            if (response.Status.Equals(true))
            {
                ViewBag.Info = response.Message;
                ViewBag.Status = response.Status;
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<AllTodoItemResponse> GetAllItems()
           => await httpClientHelper.GetResultAsync<AllTodoItemResponse>($"{APIRoutes.TodoPath}/allTodoItems");
        private async Task<AllTodoItemResponse> GetAllMyItems()
            => await httpClientHelper.GetResultAsync<AllTodoItemResponse>($"{APIRoutes.TodoPath}/userTodoItems/{UserId()}", GetUserToken());
        private async Task<SingleItemResponse> GetAnItem(int itemId)
            => await httpClientHelper.GetResultAsync<SingleItemResponse>($"{APIRoutes.TodoPath}/getItem/{itemId}", GetUserToken());
        private string UserId() => HttpContext.Session.GetString("_tokenUserId");
        private string GetUserToken() => HttpContext.Session.GetString("_token");
    }
}
