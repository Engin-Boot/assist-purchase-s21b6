using System.Net.Mail;
using ProductInfoApi.EmailProvider;
using ProductInfoApi.EmailProviderService;
using Xunit;

namespace ProductInfoApi.Tests
{
    public class EmailProviderTester
    {
        [Fact]
        public void GetToEmailAddress()
        {
            Assert.Equal("venkatesh_cs@outlook.com", EmailNotifier.GetToAddress());
        }

        [Fact]
        public void GetFromEmailAddress()
        {
            Assert.Equal("venky1998@live.com", EmailNotifier.GetFromAddress().ToString());
        }

        [Fact]
        public void CheckSmtpServerIsValid()
        {
            var obj = new EmailNotifier();
            Assert.True(obj.GetEmailServerDetails() != null);
        }

        [Fact]
        public void CheckIfMailBodyDetailsIsValid()
        {
            var emailFormat = new EmailFormat("abc", "99999999", "vejk@hsdh.com", "Illllkslk");
            var obj = new EmailNotifier();
            Assert.False(obj.GetMailMessage(emailFormat) == null);
        }

        [Fact]
        public void WhenNoAuthenticationIsProvidedThrowError()
        {
            var obj = new EmailNotifier();
            var emailFormat = new EmailFormat("abc", "99999999", "vejk@hsdh.com", "Illllkslk");
            Assert.Throws<SmtpException>(() => obj.SendCustomerInterestDetailsToMarketingTeam(emailFormat));
        }
    }
}
