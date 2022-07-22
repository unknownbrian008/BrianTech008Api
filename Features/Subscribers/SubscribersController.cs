using AutoMapper;
using BrianTech008Api.Data;
using BrianTech008Api.Data.Models;
using BrianTech008Api.Features.Subscribers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrianTech008Api.Features.Subscribers
{
    
    public class SubscribersController : BaseController
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public SubscribersController(IUnitOfWork uow, IMapper mapper)
        {

            this.uow = uow;
            this.mapper = mapper;
        }
        //Get api/category/post --Post the data in JSON format
        [HttpPost("post")]
        public async Task<IActionResult> AddSubscriber(SubscriberDto subscriberDto)
        {

            var subscriber = mapper.Map<Subscriber>(subscriberDto);
            subscriber.PostedBy = "BrianTech008";
            subscriber.LastUpdatedBy = "BrianTech008";
            subscriber.LastUpdatedOn = DateTime.UtcNow;
            subscriber.PostedOn = DateTime.UtcNow;
            //subscriber.Status = 1;
            uow.SubscriberRepository.AddSubscriber(subscriber);
            await uow.SaveAsync();
            return StatusCode(201);
        }

    }
}
