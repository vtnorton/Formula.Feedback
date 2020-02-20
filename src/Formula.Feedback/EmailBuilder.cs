using System;

namespace Formula.Feedback
{
    public class EmailBuilder
    {
        public string MountMessage(string content, string senderEmail)
        {
            string message = $"This feedback was sent by: <a href='mailto:{senderEmail}'>{senderEmail}</a>";

            message += $"This feedback was send at: {DateTime.Now}";
            message += $"<br />{content}";

            return message;
        }
    }
}
