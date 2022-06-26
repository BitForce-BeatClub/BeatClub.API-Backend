using System;
using BeatClub.API.Security.Domain.Models;

namespace BeatClub.API.BeatClub.Domain.Models
{
    public class Track
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string Genre { get; set; }
        public string Privacy { get; set; }
        
        public string Artist { get; set; }
        
        public string Cover { get; set; }
        
        public string Source { get; set; }
        
        public DateTime PublishDate { get; set; }
        
        //Relationships
        public int UserId { get; set; }
        public User User { get; set; }
    }
}