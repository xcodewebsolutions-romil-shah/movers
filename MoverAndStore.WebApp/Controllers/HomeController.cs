using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoverAndStore.WebApp.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
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
        public async Task<IActionResult> Index()
        {
            try
            {
                var fullName = User.FindFirstValue(ClaimTypes.Name);
                var client = _httpClientFactory.CreateClient();
                var requestData = new
                {
                    foreman_name = fullName,
                };

                string json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"https://hook.eu2.make.com/0axyvo1uh9vvr1i98upg70vh9ns86jnt", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = System.Text.Json.JsonSerializer.Deserialize<List<DealData>>(jsonData);
                    return View(data);
                }
                else
                {
                    return View(new List<DealData>());
                }


            }
            catch (Exception ex)
            {
                return View(new List<DealData>());
            }
        }


        
        public async Task<IActionResult> Details(string id)
        {

            try
            {
                var Foremanname = User.FindFirstValue(ClaimTypes.Name);
                var client = _httpClientFactory.CreateClient();
                var requestData = new
                {
                    foreman_name = Foremanname,
                };

                string json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"https://hook.eu2.make.com/0axyvo1uh9vvr1i98upg70vh9ns86jnt", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = System.Text.Json.JsonSerializer.Deserialize<List<DealData>>(jsonData);
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
                return View(new List<DealData>());
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
                    DealData cardData = Mapper.Map(model);
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

        public async Task<IActionResult> Task()
        {
            try
            {
                var fullName = User.FindFirstValue(ClaimTypes.Name);
                var client = _httpClientFactory.CreateClient();
                var requestData = new
                {
                    foreman_name = fullName,
                };

                string json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync($"https://hook.eu2.make.com/t9tlv377fglv4y8c8cx6kb6g8qcpifwn", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var data = System.Text.Json.JsonSerializer.Deserialize<TaskData>(jsonData);
                    return View(data);
                }
                return View(new TaskData());
            }
            catch (Exception ex)
            {
                return View(new TaskData());
            }
        }

        public async Task<IActionResult> UpdateTask([FromBody] UpdateTask model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //DealData cardData = Mapper.Map(model);
                    var Foremanname = User.FindFirstValue(ClaimTypes.Name);
                    var finalmodel = new
                    {
                        id = model.Id,
                        status = true,
                        foreman_name = Foremanname
                    };
                    string jsonString = JsonConvert.SerializeObject(finalmodel);

                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    using (var httpClient = new HttpClient())
                    {
                        var response = await httpClient.PostAsync("https://hook.eu2.make.com/cgrwhim4hmfarrdbsf2w3bx57237zj7m", content);
                        var jsonData = await response.Content.ReadAsStringAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            var responseData = await response.Content.ReadAsStringAsync();
                            var data = System.Text.Json.JsonSerializer.Deserialize<UpdateTaskResponse>(responseData);
                            return Json(new { success = true, message = data.message });
                        }
                        else
                        {
                            return Json(new { success = false, message = "Failed to update due to some error." });
                        }

                    }
        

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

