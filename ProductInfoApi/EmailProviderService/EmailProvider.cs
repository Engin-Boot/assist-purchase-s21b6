using System.Net;
using System.Net.Mail;
using ProductInfoApi.EmailProvider;

namespace ProductInfoApi.EmailProviderService
{
    public class EmailNotifier : IEmailProvider
    {
        public object SendCustomerInterestDetailsToMarketingTeam(EmailFormat email)
        {
            var mailMessage = GetMailMessage(email);
            var smtpClient = GetEmailServerDetails();
            smtpClient.Send(mailMessage);
            return 1;
        }
        public MailMessage GetMailMessage(EmailFormat email)
        {
            var mailMessage = new MailMessage {From = GetFromAddress()};
            mailMessage.To.Add(GetToAddress());
            //mailMessage.To.Add("abc@gmail.com");
            mailMessage.Subject = email.Subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = email.Body;
            return mailMessage;
        }

        public static string GetToAddress()
        {
            return "venkatesh_cs@outlook.com";
        }

        public static MailAddress GetFromAddress()
        {
            return new MailAddress("venky1998@live.com");
        }

        // ReSharper disable once MemberCanBeMadeStatic.Global
        public SmtpClient GetEmailServerDetails()
        {
            var smtpClient = new SmtpClient
            {
                Port = 587,
                Host = "smtp-mail.outlook.com",
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = GetSenderEmailCredentials(),
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            return smtpClient;
        }

        //Need to add credentials to operate
        private static ICredentialsByHost GetSenderEmailCredentials()
        {
            return new NetworkCredential("abc@gmail.com".TrimEnd(), "NahiBataunga".TrimEnd());
        }
    }
}
