using AutoMapper;
using BeatClub.API.Security.Domain.Models;
using BeatClub.API.Security.Domain.Services.Communication;
using BeatClub.API.Security.Resources;

namespace BeatClub.API.Security.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, AuthenticateResponse>();
            CreateMap<User, UserResource>();
        }
    }
}