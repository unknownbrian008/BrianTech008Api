namespace BrianTech008Api.Features.Identity
{
    public interface IIdentityService
    {
        string GenerateJwtToken(string userId, string userName, string secret);

        bool CheckUserAvailabity(string userName);
    }


}
