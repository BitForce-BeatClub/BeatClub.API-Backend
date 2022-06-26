using System;
using BeatClub.API.Security.Domain.Models;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        public string Content { get; set; }
        
        public DateTime MessageDate { get; set; }
        
        //Relationships
        public int UserIdFrom { get; set; }
        public User UserFrom { get; set; }
        
        public int UserIdTo { get; set; }
        public User UserTo { get; set; }
    }
}