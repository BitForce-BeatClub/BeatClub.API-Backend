using AutoMapper;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Resources;

namespace BeatClub.API.Learning.Mapping
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
        }
    }
}