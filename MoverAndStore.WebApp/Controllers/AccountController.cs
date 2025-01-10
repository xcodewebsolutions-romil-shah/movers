using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MoverAndStore.WebApp.Models;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MoverAndStore.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IClaimHelper _claimHelper;

        public AccountController(IConfiguration config, IClaimHelper claimHelper)
        {
            _config = config;
            _claimHelper = claimHelper;
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
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }



        [HttpPost]
        public async Task<ActionResponseDto<string>> ChangePassword(string newPassword, string oldPassword)
        {
            var response = new ActionResponseDto<string>();
            try
            {
                if (!string.IsNullOrEmpty(newPassword) && !string.IsNullOrEmpty(oldPassword))
                {
                    string hashedOldPassword = GetMd5Hash(oldPassword);

                    //var user = _unitOfWork.UserRepository.Query().FirstOrDefault(x => x.UserID == _claimHelper.UserId && x.PasswordSalt == hashedOldPassword);
                    //if (user == null)
                    //{
                    //    response.SetError("Incorrect old password.");
                    //    return response;
                    //}
                    string hashedNewPassword = GetMd5Hash(newPassword);
                    //user.PasswordSalt = hashedNewPassword;
                    //_unitOfWork.UserRepository.Update(user);
                    //await _unitOfWork.SaveChangesAsync();
                    response.SetSuccess("success");
                    return response;
                }
                response.SetError("Requested data is null or empty.");
                return response;
            }
            catch (Exception ex)
            {
                response.SetError(ex.Message);
                return response;
            }
        }

        // Helper method to compute MD5 hash
        private string GetMd5Hash(string input)
        {
            var salt = _config.GetValue<string>("AppSettings:KeySalt");
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] saltBytes = Encoding.ASCII.GetBytes(salt);

                byte[] combinedBytes = new byte[inputBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(inputBytes, 0, combinedBytes, 0, inputBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, combinedBytes, inputBytes.Length, saltBytes.Length);

                byte[] hashBytes = md5.ComputeHash(combinedBytes);
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }





    }
}
