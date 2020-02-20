using Formula.Feedback.Model;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Formula.Feedback.Services
{
    public class FeedbackServices
    {
        private string _email;
        private string _emailName;

        public FeedbackServices()
        {
            _email = Environment.GetEnvironmentVariable("Email");
            _emailName = Environment.GetEnvironmentVariable("EmailName");
        }

        public async Task SendFeedbackAsync(Email email)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_KEY");
            var client = new SendGridClient(apiKey);

            var to = new EmailAddress(_email, _emailName);
            var from = new EmailAddress(email.SenderEmail, email.SenderEmail);
            var subject = email.Subject;

            var plainTextContent = email.Content;
            var htmlContent = email.Content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
