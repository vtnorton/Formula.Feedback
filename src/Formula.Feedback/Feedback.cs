using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Formula.Feedback.Services;
using System;
using System.Threading.Tasks;
using Formula.Feedback.Model;
using System.Text.Json;
using System.IO;

namespace Formula.Feedback
{
    public class Feedback
    {
        private FeedbackServices _feedbackServices;
        public Feedback(FeedbackServices feedbackServices) => _feedbackServices = feedbackServices;

        [FunctionName("Send")]
        public async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            try
            {
                var content = await new StreamReader(req.Body).ReadToEndAsync();
                var emailInput = JsonSerializer.Deserialize<EmailInput>(content);

                var email = new Email(emailInput);

                await _feedbackServices.SendFeedbackAsync(email);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
