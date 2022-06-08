using System;

namespace BeatClub.API.Learning.Resources
{
    public class MessageResource
    {
        public int Id { get; set; }
        public string Content { get; set; }
        //public DateTime CreatAt { get; set; }
        public UserResource User { get; set; }
    }
}