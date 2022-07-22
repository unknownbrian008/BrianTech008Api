using BrianTech008Api.Data.Models;

namespace BrianTech008Api.Features.Subscribers
{
    public interface ISubscriberRepository
    {
        void AddSubscriber(Subscriber subscriber);
    }
}
