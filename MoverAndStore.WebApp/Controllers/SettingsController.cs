using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoverAndStore.WebApp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MoverAndStore.WebApp.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly HttpClient _httpClient;

        public SettingsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSMTPDetails()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://hook.eu2.make.com/h922wsdn3b3i9g0mnodc5qkwp0svh89t");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SmtpSettings>(jsonData);
                    if (result != null)
                    {
                        return Json(new
                        {
                            data = new
                            {
                                Id = result.Id,
                                email = result.Email,
                                password = result.Password,
                                domain = result.Domain
                            }
                        });
                    }
                    else
                        return Json(new { success = false, message = "Failed to fetch data." });
                }
                else
                    return Json(new { success = false, message = "API call failed." });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> SaveSmtpSettings([FromBody] SmtpSettings settings)
        {
            if (string.IsNullOrEmpty(settings.Id) || string.IsNullOrEmpty(settings.Email) || string.IsNullOrEmpty(settings.Password) || string.IsNullOrEmpty(settings.Domain))
                return BadRequest("All fields are required.");
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(settings), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://hook.eu2.make.com/q35r6yc9bun1ow5uxle7276fvjq32noj", content);

                if (response.IsSuccessStatusCode)
                    return Ok(new { success = true, message = "SMTP settings saved successfully." });
                else
                    return StatusCode((int)response.StatusCode, new { success = false, message = "Failed to send data to webhook." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"An error occurred: {ex.Message}" });
            }
        }




    }
}
