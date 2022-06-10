using System;
using BeatClub.API.Learning.Domain.Models;

namespace BeatClub.API.Learning.Resources
{
    public class SongListResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public UserResource User { get; set; }
        
    }
}