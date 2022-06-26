using System;

namespace BeatClub.API.BeatClub.Resources
{
    public class MessageResource
    {
        public int Id { get; set; }
        public string Content { get; set; }
        //public DateTime CreatAt { get; set; }
        public string UserProducerId { get; set; }
        public DateTime CreateAt { get; set; }
        public string UserArtistId { get; set; }
    }
}