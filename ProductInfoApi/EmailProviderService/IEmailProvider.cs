namespace ProductInfoApi.EmailProvider
{
    public interface IEmailProvider
    {
        object SendCustomerInterestDetailsToMarketingTeam(EmailFormat email);
    }
}