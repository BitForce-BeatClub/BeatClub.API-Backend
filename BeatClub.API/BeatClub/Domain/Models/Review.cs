using System;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        
        public string Description { get; set; }
        
        public int Qualification { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        public int UserProducerId { get; set; }
        public User UserProducer { get; set; }
        public int UserArtistId { get; set; }
        public User UserArtist { get; set; }
        
    }
}