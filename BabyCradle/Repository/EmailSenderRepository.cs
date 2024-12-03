using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace BabyCradle.Repository
{
    public class EmailSenderRepository:IEmailSenderRepository
    {
        private readonly string _apiKey;

        public EmailSenderRepository(IConfiguration configuration)
        {
            _apiKey = configuration["SendGrid:ApiKey"];
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("your-email@example.com", "YourAppName"),
                Subject = subject,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            await client.SendEmailAsync(msg);
        }
       

      
    }

}
