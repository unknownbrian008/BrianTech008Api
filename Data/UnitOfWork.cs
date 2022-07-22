
using BrianTech008Api.Data;
using BrianTech008Api.Features.Identity;
using BrianTech008Api.Features.Subscribers;
using BrianTech008Api.Features.Email;

namespace BrianTech008Api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;

        public UnitOfWork(DataContext dc)
        {
            this.dc = dc;
        }

        public IIdentityRepository IdentityRepository => new IdentityRepository(dc);
        public ISubscriberRepository SubscriberRepository => new SubscriberRepository(dc);
        
      
        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
       
    }
}
