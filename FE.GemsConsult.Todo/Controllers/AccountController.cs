using FE.GemsConsult.Todo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Project.Service.Constants;
using Project.Service.Helpers;
using Project.Service.Models.Requests;
using Project.Service.Models.Responses;

namespace FE.GemsConsult.Todo.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClientHelper httpClientHelper;
        public AccountController(HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                ModelState.AddModelError(string.Empty, "Error encounterer");

            var request = new CreateAccountRequest
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword
            };
            var response = await httpClientHelper.PostContentAsync<CreateAccountRequest, BaseResponse>(request, $"{APIRoutes.Auth2Path}/userRegistration");
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

            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                ModelState.AddModelError(string.Empty, "Error encounterer");

            var request = new LoginRequest
            {
                Email = model.Email,
                Password = model.Password,
            };
            var response = await httpClientHelper.PostContentAsync<LoginRequest, LoginResponse>(request, $"{APIRoutes.Auth2Path}/securedLogin");
            if (response.Status.Equals(true))
            {
                var claims = JwtHelper.GetTokenDataResponse(response.Data.Token.TokenValue);
                HttpContext.Session.SetString("_token", response.Data.Token.TokenValue);
                HttpContext.Session.SetString("_tokenUserId", claims.Claims.First(c => c.Type.Equals("userId")).Value);

                ModelState.Clear();
                return RedirectToAction("Index", "Todo");
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
