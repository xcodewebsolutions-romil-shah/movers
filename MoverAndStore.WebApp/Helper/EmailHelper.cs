using MoverAndStore.WebApp.Models;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

public interface IEmailHelper
{
    Task SendEmailAsync(SendMailRequestDto emailRequest);
}

public class EmailHelper : IEmailHelper
{
    private readonly HttpClient _httpClient;
    private readonly string _smtpHost = "smtp.gmail.com"; // Default SMTP server address
    private readonly int _smtpPort = 587; // Default SMTP server port    

    public EmailHelper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendEmailAsync(SendMailRequestDto emailRequest)
    {
        try
        {
            var smtpSettings = await GetSmtpSettingsAsync();
            var smtpHost = smtpSettings?.Domain ?? _smtpHost;
            var smtpUsername = smtpSettings?.Email;
            var smtpPassword = smtpSettings?.Password;

            if (string.IsNullOrEmpty(smtpUsername) || string.IsNullOrEmpty(smtpPassword))
            {
                throw new InvalidOperationException("SMTP settings are missing.");
            }

            var smtpClient = new SmtpClient(_smtpHost)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailRequest.FromEmailAddress),
                Subject = emailRequest.Subject,
                Body = emailRequest.Body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(emailRequest.ToEmailAddress);

            await smtpClient.SendMailAsync(mailMessage);
        }
        catch (SmtpException smtpEx)
        {
            Console.WriteLine("SMTP Exception: " + smtpEx.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("General Exception: " + ex.Message);
            throw;
        }
    }

    private async Task<SmtpSettings> GetSmtpSettingsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("https://hook.eu2.make.com/h922wsdn3b3i9g0mnodc5qkwp0svh89t");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SmtpSettings>(jsonData);
            }
            else
            {
                throw new InvalidOperationException("Failed to fetch SMTP settings.");
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error retrieving SMTP settings: {ex.Message}");
        }
    }


}
