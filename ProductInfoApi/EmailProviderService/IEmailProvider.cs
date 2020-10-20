namespace ProductInfoApi.EmailProviderService
{
    public interface IEmailProvider
    {
        object SendCustomerInterestDetailsToMarketingTeam(EmailFormat email);
    }
}