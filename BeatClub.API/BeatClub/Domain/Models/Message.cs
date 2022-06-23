using System;
using BeatClub.API.Security.Domain.Models;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Message
    {
        public int Id { get; set; }
        
        public string Content { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        //Relationships
        public int UserProducerId { get; set; }
        public User UserProducer { get; set; }
        public int UserArtistId { get; set; }
        public User UserArtist { get; set; }
    }
}