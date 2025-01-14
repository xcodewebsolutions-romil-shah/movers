using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoverAndStore.WebApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
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
        public async Task<IActionResult> Index(string formenName)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://hook.eu2.make.com/0axyvo1uh9vvr1i98upg70vh9ns86jnt?foreman_name={formenName}");

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
            catch (Exception ex)
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
                    var finaldata = data.Where(x => x.Basic_Information.id == id).FirstOrDefault();
                    return View(finaldata);
                }
                else
                {
                    return View(null);
                }
            }
            catch (Exception ex)
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
        public async Task<IActionResult> Save([FromBody] SaveDataModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CardData cardData = Mapper.Map(model);
                    string jsonString = JsonConvert.SerializeObject(cardData);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.PostAsync("https://hook.eu2.make.com/c3pqlr90n0h8tvpkj8i248u1ssngbihx", content);
                        var jsonData = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {

                        }

                    }
                    return Json(new { success = true, message = jsonString });

                }
                else
                {
                    return Json(new { success = false, message = "Invalid data." });
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }


        }

    }       
}

