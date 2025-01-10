using MoverAndStore.WebApp.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public interface IEmailHelper
{
    Task SendEmailAsync(SendMailRequestDto emailRequest);
}

public class EmailHelper : IEmailHelper
{
    private readonly string _smtpHost = "smtp.gmail.com"; // SMTP server address
    private readonly int _smtpPort = 587; // SMTP server port
    private readonly string _smtpUsername = "twinkle.xcode@gmail.com"; // SMTP username
    private readonly string _smtpPassword = "ocqs tgmh dyeu omsb"; // SMTP password

    public async Task SendEmailAsync(SendMailRequestDto emailRequest)
    {
        try
        {
            var smtpClient = new SmtpClient(_smtpHost)
            {
                Port = _smtpPort,
                Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
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
            // Log SMTP specific exception
            Console.WriteLine("SMTP Exception: " + smtpEx.Message);
            throw;
        }
        catch (Exception ex)
        {
            // Log general exception
            Console.WriteLine("General Exception: " + ex.Message);
            throw;
        }
    }
}
