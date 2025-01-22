using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoverAndStore.WebApp.Models;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace MoverAndStore.WebApp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IEmailHelper _emailHelper;

        public UsersController(HttpClient httpClient, IEmailHelper emailHelper)
        {
            _httpClient = httpClient;
            _emailHelper = emailHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://hook.eu2.make.com/dosmsl3ugl9ebhr8k26n9oo6rmtfmy5p");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<UserDtoApiResponse>(jsonData);
                    if (result != null)
                        return Json(new { success = true, data = result.Data });
                    else
                        return Json(new { success = false, message = "Failed to fetch data." });
                }
                else
                {
                    return Json(new { success = false, message = "API call failed." });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string userName, string password, string email, string role)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(role))
            {
                return BadRequest("All fields are required.");
            }

            var response = await _httpClient.GetAsync("https://hook.eu2.make.com/dosmsl3ugl9ebhr8k26n9oo6rmtfmy5p");
            if (!response.IsSuccessStatusCode)
            {
                return Json(new { success = false, message = "API call failed to fetch users." });
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserDtoApiResponse>(jsonData);
            if (result == null || result.Data == null)
            {
                return Json(new { success = false, message = "No users data found." });
            }

            // Check if the username or email already exists
            var userExists = result.Data.Any(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) || u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (userExists)
            {
                return Json(new { success = false, message = "Username or email already exists." });
            }

            // Create the new user
            var user = new
            {
                userName = userName,
                password = password,
                email = email,
                role = role
            };

            var jsonUser = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

            try
            {
                var createResponse = await _httpClient.PostAsync("https://hook.eu2.make.com/0grr76mcpx43stfwfj8lgv6ytoq8h42h", content);
                if (createResponse.IsSuccessStatusCode)
                {
                    string emailTemplate = @"
                <!DOCTYPE html>
                <html lang='en'>
                <head>
                    <title>Your Account Details</title>
                    <style>
                        body {
                            font-family: Arial, sans-serif;
                            background-color: #f4f4f4;
                            margin: 0;
                            padding: 0;
                        }
                        .container {
                            width: 100%;
                            max-width: 600px;
                            margin: 0 auto;
                            background-color: #ffffff;
                            border-radius: 8px;
                            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                            padding: 20px;
                        }
                        .header {
                            text-align: center;
                            padding: 10px 0;
                        }
                        .content {
                            padding: 20px;
                        }
                        .content p {
                            line-height: 1.6;
                        }
                        .footer {
                            text-align: center;
                            padding: 10px 0;
                            margin-top: 20px;
                            font-size: 0.9em;
                            color: #888;
                        }
                        .button {
                            display: inline-block;
                            padding: 5px 5px;
                            margin-top: 10px;
                            color: slateblue;
                            text-decoration: none;
                            border-radius: 5px;
                        }
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <div class='header'>                            
                            <u href='' class='app-brand-link gap-2' style='color:darkblue'>
                                <h2 style='margin: 10px 0;'>Welcome to Mover and Store!</h2>
                            </u>
                        </div>
                        <div class='content'>
                            <p>Hi {FullName}!</p>
                            <p>We are excited to have you on board with us. Your account has been created successfully, and you are now part of the Mover and Store family!</p>
                            <p><strong>Email:</strong> {EmailAddress}</p>
                            <p><strong>Password:</strong> {GeneratedPassword}</p>
                            <p>To get started, please log in to your account using the link below.</p>
                            <a href='https://smartgroup-mover.azurewebsites.net/'>Log In to Your Account</a>
                            <p>If you have any questions or need assistance, feel free to reach out to our support team.</p>
                        </div>
                        <div class='footer' style='color: slateblue;'>
                            <b>Cheers,<br>Your Mover and Store Team</b>
                        </div>
                    </div>
                </body>
                </html>";

                    string subject = "Your Account Details";
                    string body = emailTemplate
                        .Replace("{FullName}", userName)
                        .Replace("{EmailAddress}", email)
                        .Replace("{GeneratedPassword}", password);

                    var emailRequest = new SendMailRequestDto
                    {
                        FromEmailAddress = "support@test.co.za",
                        ToEmailAddress = email,
                        Subject = subject,
                        Body = body
                    };

                    await _emailHelper.SendEmailAsync(emailRequest);
                    return Json(new { success = true, message = "User created successfully." });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to create user. Please try again later." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request.UserId))
                {
                    var jsonUser = JsonConvert.SerializeObject(new { UserId = request.UserId });
                    var content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                    var response = await _httpClient.PostAsync("https://hook.eu2.make.com/sw1zs8y5xw8c8o47hs4wn34d21su3m2g", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return Json(new { success = true, message = "User deleted successfully!" });
                    }
                    else
                    {
                        return Json(new { success = false, message = "Failed to notify webhook." });
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Invalid UserId." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error occurred: " + ex.Message });
            }
        }

    }
}
