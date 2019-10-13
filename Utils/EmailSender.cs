using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FIT5032_Task2.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, String imagePath)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@easybooking.com", "Welcome to EasyBooking");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            byte[] bytes = File.ReadAllBytes(System.Web.HttpContext.Current.Server.MapPath(@"~/Uploads/" + imagePath));
            String imageContents = Convert.ToBase64String(bytes);
            msg.AddAttachment(imagePath, imageContents, "application/jpeg", "attachment", "banner");

            var response = client.SendEmailAsync(msg);

        }

    }
}