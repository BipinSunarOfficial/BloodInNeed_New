using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using BloodInNeed.UI.Models;

namespace BloodInNeed.UI.Services
{
    public class EmailService
    {
        private readonly SMTPSettings _settings;
        private readonly ILogger<EmailService> _logger;

        private BaseService _baseService;
        public EmailService(IOptions<SMTPSettings> options, ILogger<EmailService> logger, BaseService baseService)
        {
            _settings = options.Value;
            _logger = logger;
            _baseService = baseService;
        }




        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var smtpSettings = _baseService.getSmtpSettings();

                var message = new MailMessage();
                message.From = new MailAddress(smtpSettings.SenderEmail, smtpSettings.SenderName);
                message.To.Add(new MailAddress(toEmail));
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;


                _logger.LogInformation("Sending Email data : " + message);

                using var client = new SmtpClient(smtpSettings.SmtpServer, smtpSettings.Port)
                {
                    Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password),
                    EnableSsl = true
                };

                await client.SendMailAsync(message);
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogInformation("Email Sending error : " + ex.Message);
                return false;
            }

        }
    }
}
