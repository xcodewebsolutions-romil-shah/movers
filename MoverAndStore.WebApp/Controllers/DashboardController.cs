using Microsoft.AspNetCore.Mvc;
using MoverAndStore.WebApp.Models;
using System.Net.Http;
using System.Text.Json;

namespace MoverAndStore.WebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<IActionResult> Details(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://hook.eu2.make.com/0axyvo1uh9vvr1i98upg70vh9ns86jnt"); // Replace with your API endpoint
            //var response = await client.GetAsync($"https://hook.eu2.make.com/0axyvo1uh9vvr1i98upg70vh9ns86jnt"); // Replace with your API endpoint

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<List<DealData>>(jsonData);
                var finaldata = data.FirstOrDefault();
                return View(finaldata);
            }
            else
            {
                return View(null);
            }
        }

        

    }
}
