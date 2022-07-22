
using System.Threading.Tasks;
using BrianTech008Api.Features.Subscribers;
using BrianTech008Api.Features.Identity;
using BrianTech008Api.Features.Email;


namespace BrianTech008Api.Data
{
    public interface IUnitOfWork
    {
        ISubscriberRepository SubscriberRepository { get; }
        IIdentityRepository IdentityRepository { get; }
        //IEmailRepository EmailRepository { get; }
        
        Task<bool> SaveAsync();
    }


}
