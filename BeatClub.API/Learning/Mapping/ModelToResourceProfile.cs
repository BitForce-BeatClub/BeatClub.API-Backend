﻿using AutoMapper;
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
            CreateMap<SongList, SongListResource>();
            CreateMap<Song, SongResource>();
            CreateMap<Publication, PublicationResource>();
        }
    }
}