using BrianTech008Api.Data;
using BrianTech008Api.Data.Models;
using BrianTech008Api.Features.Identity;

namespace BrianTech008Api.Features.Identity
{
    public class IdentityRepository : IIdentityRepository
    {

        private readonly DataContext dc;

        public IdentityRepository(DataContext dc)
        {
            this.dc = dc;
        }
        //public void AddIdentity(Identity identity)
        //{
            //dc.Identitys.Add(identity);
        //}
    }
}
