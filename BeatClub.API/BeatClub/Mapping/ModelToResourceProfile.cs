using AutoMapper;
using BeatClub.API.BeatClub.Domain.Models;
using BeatClub.API.BeatClub.Resources;
using BeatClub.API.Security.Domain.Models;
using BeatClub.API.Security.Resources;

namespace BeatClub.API.BeatClub.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>();
            CreateMap<Message, MessageResource>();
            CreateMap<Track, TrackResource>();
            CreateMap<Publication, PublicationResource>();
            CreateMap<Membership, MembershipResource>();
            CreateMap<Review,ReviewResource>();
            CreateMap<Payment,PaymentResource>();
        }
    }
}