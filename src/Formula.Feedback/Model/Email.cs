using System;

namespace Formula.Feedback.Model
{
    public class Email
    {
        private string _projectName;
        private EmailBuilder _emailBuilder;

        public Email(EmailInput email)
        {
            _projectName = Environment.GetEnvironmentVariable("ProjectName");
            _emailBuilder = new EmailBuilder();

            Subject = $"[{_projectName} feedback]: {email.Subject}";
            Content = _emailBuilder.MountMessage(email.Content, email.SenderEmail.ToLower());
            SenderEmail = email.SenderEmail.ToLower();
        }

        public string Subject { get; }
        public string Content { get; }
        public string SenderEmail { get; }
    }
}
