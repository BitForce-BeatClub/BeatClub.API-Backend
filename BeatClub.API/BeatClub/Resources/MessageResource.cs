using System;

namespace BeatClub.API.BeatClub.Resources
{
    public class MessageResource
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime MessageDate { get; set; }
        public int UserIdFrom { get; set; }
        public int UserIdTo { get; set; }
        
    }
}