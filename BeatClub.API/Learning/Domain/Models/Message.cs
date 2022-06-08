using System;

namespace BeatClub.API.Learning.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        public string Content { get; set; }
        
        //public DateTime CreatAt { get; set; }
        
        //Relationships
        public int UserId { get; set; }
        public User User { get; set; }
    }
}