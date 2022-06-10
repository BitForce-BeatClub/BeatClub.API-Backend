using AutoMapper;
using BeatClub.API.Learning.Domain.Models;
using BeatClub.API.Learning.Resources;

namespace BeatClub.API.Learning.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveMessageResource, Message>();
            CreateMap<SaveSongListResource, SongList>();
        }
    }
}