using AutoMapper;
using BrianTech008Api.Data.Models;
using BrianTech008Api.Features.Identity.Dtos;
using BrianTech008Api.Features.Subscribers;
using BrianTech008Api.Features.Email;


namespace BrianTech008Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Identity, IdentityDto>().ReverseMap();
            CreateMap<Identity, IdentityDetailDto>().ReverseMap();

            //CreateMap<Subscriber, SubscriberDto>().ReverseMap();
            //CreateMap<Subscriber, SubscriberDetailDto>().ReverseMap();

            //CreateMap<Email, EmailDto>().ReverseMap();
            //CreateMap<Email, EmailDetailDto>().ReverseMap();


        }


    }
}
