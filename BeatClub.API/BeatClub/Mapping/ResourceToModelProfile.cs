using AutoMapper;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Resources;
using BeatClub.API.Security.Domain.Models;
using BeatClub.API.Security.Resources;

namespace BeatClub.API.BeatClub.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            //CreateMap<SaveUserResource, User>();
            CreateMap<SaveMessageResource, Message>();
            CreateMap<SaveTrackResource, Track>();
            CreateMap<SavePublicationResource, Publication>();
            CreateMap<SaveMembershipResource, Membership>();
            CreateMap<SaveReviewResource, Review>();
            CreateMap<SavePaymentResource, Payment>();
        }
    }
}