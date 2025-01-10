using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoverAndStore.WebApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MoverAndStore.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://hook.eu2.make.com/0axyvo1uh9vvr1i98upg70vh9ns86jnt");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = System.Text.Json.JsonSerializer.Deserialize<List<CardData>>(jsonData);
                    return View(data);
                }
                else
                {
                    return View(new List<CardData>());
                }


            }
            catch(Exception ex)
            { 
                return View(new List<CardData>());
            }
        }

        public async Task<IActionResult> Details(string id)
        {

            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://hook.eu2.make.com/0axyvo1uh9vvr1i98upg70vh9ns86jnt"); // Replace with your API endpoint

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = System.Text.Json.JsonSerializer.Deserialize<List<CardData>>(jsonData);
                    var finaldata = data.FirstOrDefault();
                    return View(finaldata);
                }
                else
                {
                    return View(null);
                }
            }
            catch(Exception ex)
            {
                return View(new List<CardData>());
            }
           
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public string Save([FromBody] CardData model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Simulate saving data to the database
                    //bool isSaved = SaveToDatabase(model);

                    // if (isSaved)
                    // {
                    string jsonString = JsonConvert.SerializeObject(model);
                    return jsonString;
                    //return Json(new { success = true });
                    //}
                    //else
                    //{
                    //    return Json(new { success = false, message = "Failed to save data." });
                    //}
                }
                return "Invalid Data";
                //return Json(new { success = false, message = "Invalid data." });
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }


    }
}

