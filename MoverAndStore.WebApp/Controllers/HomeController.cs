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
            catch (Exception ex)
            {
                return View(new List<CardData>());
            }
        }

        public async Task<IActionResult> Details(string formanName)
        {

            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"https://hook.eu2.make.com/0axyvo1uh9vvr1i98upg70vh9ns86jnt?{formanName}"); // Replace with your API endpoint

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
                        if(response.IsSuccessStatusCode)
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
            
        public class SaveDataModel
        {
            [JsonPropertyName("title")]
            public string Title { get; set; }
            public string Summary { get; set; }
            public string Address_A { get; set; }
            public string Address_B { get; set; }
            public string Address_C { get; set; }
            public string Status { get; set; }
            public string Company { get; set; }
            public string Customer { get; set; }
            public bool Pv1Bool { get; set; }
            public bool Pv3Bool { get; set; }
            public bool Pv2Bool { get; set; }
            public string Reference { get; set; }
            public string Contact_Person { get; set; }

            //public string Pv_Extra_Info { get; set; }
            public string Extra_Info_Lift { get; set; }
            public string Lift_Location_Enum { get; set; }
            public string Lift_Type_Enum { get; set; }
            public int Number_Of_Movers { get; set; }
            public int Number_Of_Movers_Update { get; set; }
            //public string Date_In { get; set; }
            //public string Date_In_Update { get; set; }
            //public string Date_Out { get; set; }
            //public string Date_Out_Update { get; set; }

            //[JsonPropertyName("cubic_meters")]
            //public int Cubic_Meters { get; set; }

            //[JsonPropertyName("cubic_meters_update")]
            //public int Cubic_Meters_Update { get; set; }

            [JsonPropertyName("time_estimate")]
            public string Time_Estimate { get; set; }

            [JsonPropertyName("time_estimate_update")]
            public int Time_Estimate_Update { get; set; }

            //[JsonPropertyName("items_to_dismantle")]
            //public string Items_To_Dismantle { get; set; }

            //[JsonPropertyName("items_to_dismantle_update")]
            //public string Items_To_Dismantle_Update { get; set; }

            //[JsonPropertyName("additional_general_info")]
            //public string Additional_General_Info { get; set; }

            //[JsonPropertyName("additional_general_info_update")]
            //public string Additional_General_Info_update { get; set; }

            public bool Lift_bool { get; set; }

            //[JsonPropertyName("storage")]
            //public string Storage { get; set; }

            //[JsonPropertyName("storage_update")]
            //public string Storage_Update { get; set; }

            //[JsonPropertyName("zone")]
            //public string Zone { get; set; }

            //[JsonPropertyName("zone_update")]
            //public string Zone_Update { get; set; }

            //[JsonPropertyName("exact_location")]
            //public string Exact_Location { get; set; }

            //[JsonPropertyName("exact_location_update")]
            //public string Exact_Location_Update { get; set; }

            //[JsonPropertyName("options_enum")]
            //public string Options_Enum { get; set; }

            //[JsonPropertyName("insured_value")]
            //public string Insured_Value { get; set; }

            //[JsonPropertyName("contract")]
            //public bool Contract { get; set; }

            //[JsonPropertyName("general_extra_info")]
            //public string general_extra_info { get; set; }

            //public string id { get; set; }

            //[JsonPropertyName("name")]
            //public string name { get; set; }
            //[JsonPropertyName("quantity")]
            //public int quantity { get; set; }

            //[JsonPropertyName("quantity_update")]
            //public int quantity_update { get; set; }

            //[JsonPropertyName("foreman_notes")]
            //public string foreman_notes { get; set; }

            public string? moving_from_date { get; set; }

            public string? moving_to_date { get; set; }

            public string? client_arrival_time_update { get; set; }

            //[JsonPropertyName("lift_bool")]
            //public bool Lift_bool { get; set; }

            //[JsonPropertyName("voertuig_enum")]
            //public string Voertuig_Enum { get; set; }
            //[JsonPropertyName("voertuig_type_enum")]
            //public string Voertuig_Type_Enum { get; set; }            

            //[JsonPropertyName("dismantling_bool")]
            //public bool Dismantling_Bool { get; set; }

            //[JsonPropertyName("dismantling_bool_update")]
            //public bool Dismantling_Bool_Update { get; set; }

            

            //[JsonPropertyName("items_to_dismantle")]
            //public string Items_To_Dismantle { get; set; }

            //[JsonPropertyName("items_to_dismantle_update")]
            //public string Items_To_Dismantle_Update { get; set; }

            //[JsonPropertyName("additional_general_info")]
            //public string Additional_General_Info { get; set; }

            //[JsonPropertyName("additional_general_info_update")]
            //public string Additional_General_Info_update { get; set; }
        }


    }
}

