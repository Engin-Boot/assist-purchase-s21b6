using System.Net;
using System.Net.Mail;

namespace ProductInfoApi
{
    public class EmailNotifier
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
            return new NetworkCredential("abc@outlook.com".TrimEnd(), "NahiBataunga".TrimEnd());
        }
    }

    // ReSharper disable once ClassNeverInstantiated.Global
    public class EmailFormat
    {
        public EmailFormat(string customerName, string phoneNumber, string emailAddress, string interestedProducts)
        {
            CustomerName = customerName;
            _phoneNumber = phoneNumber;
            _interestedProducts = interestedProducts;
            CustomerEmailAddress = emailAddress;
            InitBodyOfEmail();
        }
        private void InitBodyOfEmail()
        {
            Body =
                $"Customer Name: {CustomerName} \nPhone Number:{_phoneNumber} \nInterested Products:{_interestedProducts}";
        }

        private string CustomerName
        {
            get => _customerName;
            set
            {
                _customerName = value;
                UpdateSubject();
            }
        }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        private string CustomerEmailAddress { get; }

        private void UpdateSubject()
        {
            Subject = "Interest From Customer:" + CustomerName;
        }

        public string Subject;
        private readonly string _interestedProducts;
        private readonly string _phoneNumber;
        public string Body;
        private string _customerName;
    }
}
