using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MoverAndStore.WebApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MoverAndStore.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IClaimHelper _claimHelper;
        private readonly HttpClient _httpClient;

        public AccountController(IConfiguration config, IClaimHelper claimHelper, HttpClient httpClient)
        {
            _config = config;
            _claimHelper = claimHelper;
            _httpClient = httpClient;
        }

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

                    TempData["errorMsg"] = null;
                    if (data.Success == "false")
                    {
                        TempData["userName"] = data.Email;
                        TempData["errorMsg"] = data.Message;
                        return LocalRedirect("/Account/Login");
                    }

                    var claims = new List<Claim>
                     {
                         new Claim(ClaimTypes.NameIdentifier, data.UserId),
                         new Claim(ClaimTypes.Name, data.FullName),
                         new Claim(ClaimTypes.Email, data.Email),
                         new Claim(ClaimTypes.Role, data.Role),
                     };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var authenticationProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            principal,
                            authenticationProperties);

                    if (data.Role == "Admin")
                    {
                        return LocalRedirect("/Users/Index");
                    }
                    else
                    {
                        return LocalRedirect($"/Home/Index");
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
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        public async Task<ActionResponseDto<string>> ChangePassword(string newPassword, string oldPassword)
        {
            var response = new ActionResponseDto<string>();
            try
            {
                if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(oldPassword))
                {
                    response.SetError("new password, or old password cannot be empty.");
                    return response;
                }

                var userId = _claimHelper.UserId;
                if (string.IsNullOrEmpty(userId))
                {
                    response.SetError("User is not authenticated.");
                    return response;
                }

                var userResponse = await _httpClient.GetAsync("https://hook.eu2.make.com/dosmsl3ugl9ebhr8k26n9oo6rmtfmy5p");
                if (!userResponse.IsSuccessStatusCode)
                {
                    response.SetError("API call failed to fetch users.");
                    return response;
                }

                var jsonData = await userResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<UserDtoApiResponse>(jsonData, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                    Formatting = Formatting.None,
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    Converters = new List<JsonConverter> { new StringEnumConverter() },
                });

                if (result == null || result.Data == null)
                {
                    response.SetError("No users found.");
                    return response;
                }

                // Check if the user exists
                var user = result.Data.FirstOrDefault(u => u.UserId == userId);
                if (user == null)
                {
                    response.SetError("User does not exist.");
                    return response;
                }

                // Verify old password
                if (user.Password != oldPassword)
                {
                    response.SetError("Old password does not match.");
                    return response;
                }

                // Update the password via the webhook
                var userToUpdate = new
                {
                    userId = userId,
                    newPassword = newPassword
                };

                var jsonUser = JsonConvert.SerializeObject(userToUpdate);
                var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                var updateResponse = await _httpClient.PostAsync("https://hook.eu2.make.com/i81sy7odn3qiwulw5yjxe8h7aymowf7e", content);
                if (updateResponse.IsSuccessStatusCode)
                    response.SetSuccess("Password updated successfully.");
                else
                    response.SetError("Failed to update password. Please try again.");


                return response;
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message);
                return response;
            }
        }






    }
}
