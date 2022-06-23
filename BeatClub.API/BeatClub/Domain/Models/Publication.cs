using System;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Publication
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public DateTime CreateAt { get; set; }
        
        //Relationships
        public int UserId { get; set; }
        public User User { get; set; }

    }
}