using Microsoft.AspNetCore.Mvc;
using MoverAndStore.WebApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace MoverAndStore.WebApp.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IUserService _userService;

        //public AccountController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password, string ReturnUrl = null)
        {
            try
            {
                var credentials = new Login()
                {
                    username = UserName,
                    password = Password,
                };
                string json = JsonConvert.SerializeObject(credentials);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var httpClient = new HttpClient())
                {
                    var loginresponse = await httpClient.PostAsync("https://hook.eu2.make.com/ldxe1qlmi55qalq4c947obnqvrqbmoxi", content);
                    var jsonData = await loginresponse.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<LoginResponse>(jsonData);

                    if (data.Success == "true")
                    {
                        return LocalRedirect("/Home/Index");
                    }
                    else
                    {
                        return LocalRedirect("/Home/Index");
                        //TempData["errorMsg"] = "Wrong Credentials";
                        //return RedirectToAction("Login");
                    }

                }
            }
            catch (Exception ex)
            {
                //TempData["errorMsg"] = ex.Message;
                return LocalRedirect("/Home/Index");
            }
        }

        public async Task<IActionResult> Logout()
        {
            //await HttpContext.SignOutAsync();
            return View("Logout");
        }
    }
}
