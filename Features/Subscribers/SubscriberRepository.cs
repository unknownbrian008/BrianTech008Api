using BrianTech008Api.Data;
using BrianTech008Api.Data.Models;

namespace BrianTech008Api.Features.Subscribers
{
    public class SubscriberRepository : ISubscriberRepository
    {

        private readonly DataContext dc;

        public SubscriberRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddSubscriber(Subscriber subscriber)
        {
            dc.Subscribers.Add(subscriber);
        }
    }
}
