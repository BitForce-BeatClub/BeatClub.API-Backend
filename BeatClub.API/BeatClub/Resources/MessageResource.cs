using System;

namespace BeatClub.API.BeatClub.Resources
{
    public class MessageResource
    {
        
        public int id { get; set; }
        public string content { get; set; }
        public DateTime messageDate { get; set; }
        public string userIdFrom { get; set; }
        public string userIdTo { get; set; }
    }
}